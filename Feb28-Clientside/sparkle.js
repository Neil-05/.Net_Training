  // bubbles in array
let trailArr = [1, 1.5];

// let trailArr = [1, .01, .8, .5, 01, .6, .4, 01, .2];

function trailAnimation(e, i, callbackFn) {
  var elem = document.createElement('div');

  elem = styleSparkle(elem, e, i);

  if (typeof callbackFn == 'function') {
    elem = callbackFn(elem);    
  }
  
  elem.classList.add("sparkle");

  document.body.appendChild(elem);

  window.setTimeout(function () {
    document.body.removeChild(elem);
    
    // 1000 = lifespan of particles
  }, Math.round(Math.random() * i * 200));
}

// 50 = spread of particles

//10 = size of particles

function styleSparkle(elem, e, i) {
  let j = (1 - i) * 50;
  let size = Math.ceil(Math.random() * 1 * i) + 'px';
  
  // 2 = effevescence
  
  elem.style.top = e.pageY - window.scrollY + Math.round(Math.random() * j - j / 2) + 'px';
  elem.style.left = e.pageX + Math.round(Math.random() * j - j / 2) + 'px';
  
  elem.style.width = size;
  elem.style.height = size;
  elem.style.borderRadius = size;
  
  // colour of particles
  
  // elem.style.background = 'hsla(' +
  //   Math.round(Math.random() * 250) + ', ' +
  //   '70%, ' +
  //   '70%, ' +
  //   i + ')';
  

  
  return elem;
}

window.addEventListener('mousemove', function (e) {
  trailArr.forEach((i) => {trailAnimation(e, i)});

  trailArr.forEach((i) => {trailAnimation(e, i, (elem) => {
    elem.style.animation = "fallingsparkles 1s";
    
    return elem;
  })});
}, false);