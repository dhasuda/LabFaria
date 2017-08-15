function direct(pt, lambda, distance, gt, gr) {
  var aux = lambda/(4*3.14159*distance);
  aux = aux * aux * Math.pow(10, -18);
  aux = aux * pt * dBtoStandardUnit(gt) * dBtoStandardUnit(gr);
  return aux;
}

function reflection(pt, gt, gr, ht, hr, distance) {
  return pt*dBtoStandardUnit(gt)*dBtoStandardUnit(gr)*Math.pow(ht*hr, 2)/Math.pow(distance, 4);
}

function fresnelParam(h, d1, d2, lambda) {
  return h*Math.sqrt(2*(d1+d2)/(lambda*d1*d2));
}

function difraction(pt, gt, gr, h, d1, d2, lambda) {
  var loss = 0;
  var fresnelParameter = fresnelParam(h, d1, d2, lambda);
  if (fresnelParameter <= -1) {
    loss = 0;
  }
  else if (fresnelParameter <= 0) {
    loss = 20*Math.log10(0.5 - (0.62*fresnelParameter));
  }
  else if (fresnelParameter <= 1) {
    loss = 20*Math.log10(0.5*Math.exp(-0.95*fresnelParameter));
  }
  else if (fresnelParameter <= 2.4) {
    loss = 20*Math.log10(0.4 - Math.sqrt(0.1184 - Math.pow(0.38 - 0.1*fresnelParameter, 2)));
  }
  else {
    loss = 20*Math.log10(0.225/fresnelParameter);
  }
  var dist = d1 + d2;
  dist += h*h*(d1+d2)/(2*d1*d2);

  return pt * dBtoStandardUnit(gt) * dBtoStandardUnit(gr) * Math.pow(lambda/(4*3.14159*dist), 2) * Math.pow(10, -18) / dBtoStandardUnit(loss);

}

function isViable(receivedPower, receiverSens) {
  return receivedPower > receiverSens;
}

function dBtoStandardUnit(dBValue) {
  return Math.pow(10, dBValue / 10)
}
