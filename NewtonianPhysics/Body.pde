class Body {
  PVector prevPosition = new PVector();
  PVector position = new PVector();
  PVector velocity = new PVector();
  float mass;
  color colour;

  boolean superMassive = false;
  Body() {

    colorMode(HSB);
    colour = color(random(0, 255), 255, 255);
    colorMode(RGB);

    if (random(0, 100) < 5) {
      superMassive = true;
      mass = 1000000000;
      position.x = mouseX;
      position.y = mouseY;
    } else {
      mass = random(1000, 1000000);
      velocity.y = random(-1, 1);
      velocity.x = random(-1, 1);
      position.x = random(0, width);
      position.y = random(0, height);
    }
  }
  void update() {
    prevPosition = position.copy();

    PVector forceThisFrame = new PVector();
    for (Body b : bodies) {
      if (b == this) continue;
      //apply gravity to body
      float dx = b.position.x - position.x;
      float dy = b.position.y - position.y;
      float distanceSquared = (dx*dx + dy*dy);
      if (distanceSquared < MIN_DISTANCE_SQUARED) distanceSquared = MIN_DISTANCE_SQUARED;
      float amountofForce = (float)(G * (mass * b.mass)/ distanceSquared);
      PVector forceFromB = new PVector(dx, dy);
      forceFromB.normalize();
      forceFromB.mult(amountofForce);
      //adding to the running total
      forceThisFrame.add(forceFromB);
    }
    //euler integration
    //force = mass * acceleration
    //acceleration = force / mass
    PVector acceleration = PVector.mult(forceThisFrame, 1/mass);
    velocity.add(acceleration);
    position.add(velocity);
    if (superMassive) {
      position.x = mouseX;
      position.y = mouseY;
    }
  }
  void draw() {
    noStroke();
    if (superMassive) {
      fill(255, 0, 0);
    } else {
      fill(255);
    }
    ellipse(position.x, position.y, 10, 10);

    buffer.beginDraw();
    buffer.line(prevPosition.x, prevPosition.y, position.x, position.y);
    buffer.stroke(colour);
    buffer.endDraw();
  }
}
