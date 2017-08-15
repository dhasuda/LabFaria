function vp (Ee) {
  return 299792458 / Math.sqrt(Ee);
}

function beta(f, Er) {
  return 2*3.14159 * f * Math.sqrt(Er) / 299792458;
}

function Ee (Er, Wd) {
  var a = (Er + 1)/2;
  var b = (Er - 1)/2;
  b /= Math.sqrt(1 + (12/Wd));
  return a+b;
}

function Z0 (Wd, Ee) {
  var z;
  if (Wd <= 1) {
    z = 60 * Math.log((8/Wd) + (Wd/4)) / Math.sqrt(Ee);
  }
  else {
    120 * 3.14159 / ( (Wd + 1.393 + (0.667*Math.log(Wd + 1.444))) * Math.sqrt(Ee));
  }
  return z;
}

function Wd (a, b, Er) { // If there is no need for b just insert any value
    var answer = 8 * Math.exp(a) / (Math.exp(2*a) - 2);
    if (answer > 2) {
      answer = 2 * (b - 1 - Math.log(2*b - 1) + ((Er - 1)/(2*Er)) * (Math.log(b - 1) + 0.39 - (0.61/Er))) / 3.14159;
    }
    return answer;
}

function A (z, Er) {
  var aux = (z*Math.sqrt((Er + 1)/2)) / 60;
  aux += ((Er-1)/(Er+1)) * (0.23 + (0.11/Er));
  return aux;
}

function B (z, Er) {
  return 377*3.14159 / (2*z*Math.sqrt(Er));
}

function alphaD (f, Er, Ee, tg) {
  return 2 * 3.14159 * f * Er * (Ee - 1) * tg / (299792458 * 2 * Math.sqrt(Ee) * (Er - 1));
}

function alphaC (Rs, z, w) {
  return Rs/(z*w);
}

function Rs(f, sigma) {
  return Math.sqrt(3.14159 * f * 4 * 3.14159 * Math.pow(10, -7) / sigma);
}

function lambdaGuiado (vp, f) {
  return vp / f;
}
