const letters = "abcdefghijkl+mnopqrstuvwxyz";
let lettersArray = Array.from(letters);
let lettersContainer = document.querySelector(".letters");
lettersArray.forEach((letter) => {
  // Creat span for the letter

  let letterSpan = document.createElement("span");
  //   creat textNode for the letter
  //   add class for the span
  letterSpan.className = "letter-box";
  let textNode = document.createTextNode(letter);

  //  appand textNode inside the span
  letterSpan.appendChild(textNode);
  //   append the span to the letter container
  lettersContainer.appendChild(letterSpan);
  //
});

// Put the categories in a object called words

const words = {
  Programming: ["JavaScript", "HTML", "CSS", "C++", "JAVA", "PHP", "Python"],
  Numbers: ["One", "Two", "One Hundred", "Three", "Fourteen"],
  Names: ["Falastin", "Ali", "Mohamed", "Khaled", "Bian", "Fatima"],
  Countries: ["Palestine", "Yemen", "Egypt", "Turkey"],
  languages: ["Arabic", "English", "Turkish"],
};
// Get All the property names from the Object(Arr of keys)

let allKeys = Object.keys(words);

// Get one index randomly from all the keys(Get random index from all the prop)
let randomPropertyIndex = Math.floor(Math.random() * allKeys.length);
// Get the Name of the previous random prop
let randomPropertyName = allKeys[randomPropertyIndex];
// Get all the values of this prop
let randomPropertyValue = words[randomPropertyName];
// Get random index from the previous values
let randomValueIndex = Math.floor(Math.random() * randomPropertyValue.length);
// Get the name of the pervious value index(Chosen word that has to be gussen)
let randomValueName = randomPropertyValue[randomValueIndex];
// Append the categoty to the word span
let spanCategory = document.querySelector(".category span");
spanCategory.innerHTML = randomPropertyName;
// Select the container of the Letter guess
let letterGuessContainer = document.querySelector(".letters-guess");

// Creat array from the word the has to be found from the user
let LetterAndSpacesOfTheChosenWord = Array.from(randomValueName);
// Creat Spans depends on the chosen word and its lenght
// Loop on the LetterAndSpacesOfTheChosenWord to creat spans
LetterAndSpacesOfTheChosenWord.forEach((letterOrSpace) => {
  let span = document.createElement("span");
  if (letterOrSpace === " ") {
    span.className = "space";
  }
  //   append all span to letterGuessContainer
  letterGuessContainer.appendChild(span);
});
// Count the num of wrong attempts clicking
let wrongCount = 0;
let correctCount = 0;
// Get the hangman-draw
let theHangMan = document.querySelector(".hangman-draw");

// Handle Clicking on the letter
document.addEventListener("click", (e) => {
  // You still not click a correct letter
  theStatus = false;

  if (e.target.className === "letter-box") {
    theChosenWord = Array.from(randomValueName.toLowerCase());

    e.target.classList.add("clicked");
    // get the clicked letter

    let theClickedLetter = e.target.innerHTML.toLowerCase();

    // Loop on the ChosenWord to chick the existance of the letter
    theChosenWord.forEach((letter, index) => {
      if (letter.toLowerCase() == theClickedLetter) {
        theStatus = true;
        correctCount++;
        // Loop on all the spans to put this letter in the span that is in the index
        let allSpansLetter = document.querySelectorAll(".letters-guess span");
        allSpansLetter.forEach((span, spanIndex) => {
          if (spanIndex === index) {
            span.innerHTML = theClickedLetter;
          }
        });
      }
    });

    //  OutSide the Loop to check theStatus
    if (theStatus == false) {
      wrongCount++;
      theHangMan.classList.add(`wrong-${wrongCount}`);
      //   False Letter Sound
      document.getElementById("false").play();

      if (wrongCount == 8) {
        endTheGameWithFail();
        lettersContainer.classList.add("finish");
      }
    } else {
      //   True Letter Sound
      console.log(correctCount, theChosenWord.length);
      document.getElementById("true").play();
      if (correctCount == theChosenWord.length) {
        endTheGameWithSuccess();
        lettersContainer.classList.add("finish");
      }
    }
  }
});

function endTheGameWithFail() {
  // End Div
  let finishDiv = document.createElement("div");
  //   End Text
  let finishText = document.createTextNode(
    `The Game Over, The Word Is ${randomValueName.toUpperCase()}`
  );
  //   Append Text to the div
  finishDiv.appendChild(finishText);
  //   Add class to the div
  finishDiv.className = "Game-Over-fail";
  // append to the body
  document.body.appendChild(finishDiv);
}
function endTheGameWithSuccess() {
  // End Div
  let finishDiv = document.createElement("div");
  //   End Text
  let finishText = document.createTextNode(
    `Congrats, You Win
    The number of wrong attempts equal ${wrongCount}
    `
  );
  //   Append Text to the div
  finishDiv.appendChild(finishText);
  //   Add class to the div
  finishDiv.className = "Game-Over-success";
  // append to the body
  document.body.appendChild(finishDiv);
}
