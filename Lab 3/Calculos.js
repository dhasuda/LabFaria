// Aux functions *****************************************************
function dispersionLengthMM(disp, Tbit, Brx) {
  //var tMax = Math.sqrt(Math.pow(0.1*Tbit, 2) - Math.pow(0.44/Brx, 2));
  //return tMax/disp;
  return Math.sqrt(Math.pow(0.1*Tbit, 2)/(Math.pow(0.44/Brx, 2) + Math.pow(disp, 2)));
}

function attenuationLength(attenuation, receptorSens, laserPower) {
  var dbMax = 10 * Math.log10(dBmtoStandardUnit(laserPower)/dBmtoStandardUnit(receptorSens));
  return dbMax/attenuation;
}

function dispersionLengthSM(disp, Tbit, lambda, Brx) {
  //lambda = ; // Worst case scenario is when lambda is at its max
  //var tMax = Math.sqrt(Math.pow(0.1*Tbit, 2) - Math.pow(0.44/Brx, 2));
  //var tMax = 0.1*Tbit;
  //return tMax/(disp * lambda);

  return Math.sqrt(Math.pow(0.1*Tbit, 2)/(Math.pow(0.44/Brx, 2) + Math.pow(disp*lambda, 2)));
}

// End of aux functions **********************************************


// Functions called in .html *****************************************
function lengthMM(attenuation, receptorSens, laserPower, disp, Tbit, Brx) {

  var atLength = attenuationLength(attenuation, receptorSens, laserPower);
  var dispLength = dispersionLengthMM(disp, Tbit, Brx);
  if (dispLength < atLength)   {
    return dispLength;
  }
  return atLength;
}

function lengthSM(disp, Tbit, lambda, attenuation, receptorSens, laserPower, Brx) {
  var dispLength = dispersionLengthSM(disp, Tbit, lambda, Brx);
  var atLength = attenuationLength(attenuation, receptorSens, laserPower);
  if (dispLength < atLength)   {
    return dispLength;
  }
  return atLength;
}

function dBmtoStandardUnit(dBvalue) {
  return Math.pow(10, -3) * Math.pow(10, dBvalue/10);
}