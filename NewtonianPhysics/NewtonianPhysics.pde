ArrayList<Body> bodies = new ArrayList<Body>();

PGraphics buffer; 


final double G =  .0000006673;
final float MIN_DISTANCE_SQUARED = 10000;

void setup () {

  size(400, 500);

  buffer = createGraphics(width, height);

  for (int i = 0; i < 50; i++) {
    bodies.add(new Body() );
  }
}

void draw() {

  background(0);
  buffer.beginDraw();

  //buffer.filter(BLUR, .6);
  buffer.fill(0, 0, 0, 32);
  //buffer.rect(0,0,width,height);
  buffer.endDraw();
  image(buffer, 0, 0);

  for (Body b : bodies) {
    b.update();
    b.draw();
  }
}
void mouseClicked() {
  for (int i = 0; i < 15; i++) {
    bodies.add(new Body() );
  }
}
