
float zoom = .05;
int mode = 0;
float z = 0;
void setup() {
  size(400, 400, P3D);
  drawNoise();
  //frameRate(10);
}

void draw() {
  z += .01;
  drawNoise();
}
void mouseWheel(MouseEvent e) {
  zoom += e.getCount() * .01; 
  zoom = constrain(zoom, .01, 1);
}
void drawNoise() {
  noStroke();
  colorMode(HSB);
  noiseDetail(5, .5);
  for (int x = 0; x < width; x++) {
    for (int y = 0; y < height; y++) {
      float val = noise(x*zoom, y*zoom, z);
      drawPixel(x, y, val);
    }
  }
}
void keyPressed() {
  if (keyCode == 48) mode = 0;
  if (keyCode == 49) mode = 1;
  if (keyCode == 50) mode = 2;
  if (keyCode == 51) mode = 3;
}
void drawPixel(float x, float y, float val) {
  switch(mode) {
  case 0:
    fill(val * 255);
    break;
  case 1:
    val *= 2;
    val %=1;
    fill(val * 255, 255, 255);
    break;
  case 2:
    val = map(val, .2, .7, 0, 1);
    fill(val * 255, 255, 255);
    break;
  case 3:
    fill( (val > .5 && val < .6) ? 255 : 0);
    break;
  }
  rect(x,y,1,1);
}
