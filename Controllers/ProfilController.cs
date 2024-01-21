using System;
using System.Diagnostics;
using System.IO;
using System.Xml;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http.Extensions;
using tfou.Models;

namespace tfou.Controllers
{
    public class ProfilController : Controller
    {
        private readonly ILogger<ProfilController> _logger;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfilController(ILogger<ProfilController> logger, IWebHostEnvironment webHostEnvironment)
        {
            _logger = logger;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("profil/{*any}")]
        public IActionResult Xml()
        {
            // Retrieve "avatar" cookie
            string? avatarCookie = Request.Cookies["avatar"];

            // If the cookie is null or empty, return the original XML file
            if (string.IsNullOrEmpty(avatarCookie))
            {
                return File("/profil.xml", "text/xml");
            }

            try
            {
                // Split the cookie value into separate parts
                string[] parts = avatarCookie.Split('-');

                // Validate the number of parts
                if (parts.Length != 4)
                {
                    return File("/profil.xml", "text/xml");
                }

                // Parse the values
                int hatId = int.Parse(parts[0]);
                int faceId = int.Parse(parts[1]);
                int bodyId = int.Parse(parts[2]);
                int legsId = int.Parse(parts[3]);
                // Get the path to the XML file
                string xmlFilePath = Path.Combine(_webHostEnvironment.WebRootPath, "profil.xml");

                // Load the XML file
                XmlDocument xml = new XmlDocument();
                xml.Load(xmlFilePath);

                // Modify the values in the XML
                XmlNode? avatarNode = xml.SelectSingleNode("/doc/element/avatar");
                if (avatarNode != null)
                {
                    XmlNode? hatIdNode = avatarNode.SelectSingleNode("hatId");
                    XmlNode? faceIdNode = avatarNode.SelectSingleNode("faceId");
                    XmlNode? bodyIdNode = avatarNode.SelectSingleNode("bodyId");
                    XmlNode? legsIdNode = avatarNode.SelectSingleNode("legsId");

                    if (hatIdNode != null)
                    {
                        hatIdNode.InnerText = hatId.ToString().PadLeft(3, '0');
                    }
                    if (faceIdNode != null)
                    {
                        faceIdNode.InnerText = faceId.ToString().PadLeft(3, '0');
                    }
                    if (bodyIdNode != null)
                    {
                        bodyIdNode.InnerText = bodyId.ToString().PadLeft(3, '0');
                    }
                    if (legsIdNode != null)
                    {
                        legsIdNode.InnerText = legsId.ToString().PadLeft(3, '0');
                    }
                }

                // Return the modified XML file
                return Content(xml.OuterXml, "text/xml");
            }
            catch (Exception ex)
            {
                // If the cookie value is invalid, return the original XML file
				Console.WriteLine(ex.ToString());
                return File("/profil.xml", "text/xml");
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
