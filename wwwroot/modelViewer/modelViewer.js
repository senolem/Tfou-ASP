const hatIncrementButton = document.getElementById('hat-increment');
const hatDecrementButton = document.getElementById('hat-decrement');
const faceIncrementButton = document.getElementById('face-increment');
const faceDecrementButton = document.getElementById('face-decrement');
const bodyIncrementButton = document.getElementById('body-increment');
const bodyDecrementButton = document.getElementById('body-decrement');
const legsIncrementButton = document.getElementById('legs-increment');
const legsDecrementButton = document.getElementById('legs-decrement');
const randomButton = document.getElementById('random-button');

hatIncrementButton.addEventListener('click', incrementHat);
hatDecrementButton.addEventListener('click', decrementHat);
faceIncrementButton.addEventListener('click', incrementFace);
faceDecrementButton.addEventListener('click', decrementFace);
bodyIncrementButton.addEventListener('click', incrementBody);
bodyDecrementButton.addEventListener('click', decrementBody);
legsIncrementButton.addEventListener('click', incrementLegs);
legsDecrementButton.addEventListener('click', decrementLegs);
randomButton.addEventListener('click', shuffleValues);

let hatValue = 306;
let faceValue = 193;
let bodyValue = 0;
let legsValue = 427;

function incrementHat() {
  if (hatValue < 426) {
    hatValue++;
	updateHatDisplayedValue();
    updateModelViewer();
  }
}

function decrementHat() {
  if (hatValue > 306) {
    hatValue--;
	updateHatDisplayedValue();
    updateModelViewer();
  }
}

function incrementFace() {
	if (faceValue < 305) {
	  faceValue++;
	  updateFaceDisplayedValue();
	  updateModelViewer();
	}
  }
  
function decrementFace() {
	if (faceValue > 193) {
	  faceValue--;
	  updateFaceDisplayedValue();
	  updateModelViewer();
	}
}

function incrementBody() {
	if (bodyValue < 192) {
	  bodyValue++;
	  updateBodyDisplayedValue();
	  updateModelViewer();
	}
}
  
function decrementBody() {
	if (bodyValue > 0) {
	  bodyValue--;
	  updateBodyDisplayedValue();
	  updateModelViewer();
	}
}

function incrementLegs() {
	if (legsValue < 569) {
	  legsValue++;
	  updateLegsDisplayedValue();
	  updateModelViewer();
	}
  }
  
function decrementLegs() {
	if (legsValue > 427) {
	  legsValue--;
	  updateLegsDisplayedValue();
	  updateModelViewer();
	}
}

function updateHatDisplayedValue() {
	const hatId = document.getElementById('hatId');
	hatId.innerText = (hatValue - 306).toString();
}
  
  function updateFaceDisplayedValue() {
	const faceId = document.getElementById('faceId');
	faceId.innerText = (faceValue - 193).toString();
}
  
  function updateBodyDisplayedValue() {
	const bodyId = document.getElementById('bodyId');
	bodyId.innerText = (bodyValue).toString();
}
  
  function updateLegsDisplayedValue() {
	const legsId = document.getElementById('legsId');
	legsId.innerText = (legsValue - 427).toString();
}

function shuffleValues() {
	hatValue = getRandomValueInRange(306, 426);
	faceValue = getRandomValueInRange(193, 305);
	bodyValue = getRandomValueInRange(0, 192);
	legsValue = getRandomValueInRange(427, 569);
	updateModelViewer();
	updateHatDisplayedValue();
	updateFaceDisplayedValue();
	updateBodyDisplayedValue();
	updateLegsDisplayedValue();
}


function getRandomValueInRange(min, max) {
	return Math.floor(Math.random() * (max - min + 1)) + min;
}

function updateModelViewer() {
	const hatImage = document.getElementById('hat-image');
	hatImage.src = `./assets/${pad(hatValue, 3)}.png`;
	const faceImage = document.getElementById('face-image');
	faceImage.src = `./assets/${pad(faceValue, 3)}.png`;
	const bodyImage = document.getElementById('body-image');
	bodyImage.src = `./assets/${pad(bodyValue, 3)}.png`;
	const legsImage = document.getElementById('legs-image');
	legsImage.src = `./assets/${pad(legsValue, 3)}.png`;
}

function pad(value, length) {
  return value.toString().padStart(length, '0');
}

const saveButton = document.getElementById('save-button');

saveButton.addEventListener('click', saveProfile);

function saveProfile() {
	const avatarValue = `${pad(hatValue, 3)}-${pad(faceValue, 3)}-${pad(bodyValue, 3)}-${pad(legsValue, 3)}`;
	const date = new Date();
	date.setFullYear(date.getFullYear() + 1);
	const expires = date.toUTCString();
	document.cookie = `avatar=${avatarValue}; SameSite=None; Path=/; expires=${expires}; domain=.absoluflash.co`;
	alert('Avatar sauvegardé avec succès!');
}
