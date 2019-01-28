class Boid {
  PVector position = new PVector();
  PVector velocity = new PVector();
  float angle = 0;
  PVector target = new PVector();
  PVector offset = new PVector();//add to the mouse every frame to get  a flocking effect
  float mass;
  float offsetRotationSpeed;
  final float MAX_SPEED = 10; //px/tic

  Boid() {
    position.x = random(0, width);
    position.y = random(0, height);

    offset.x = random(-100, 100);
    offset.y = random(-100, 100);
offsetRotationSpeed = random(-.1, .1);
    mass = random(50, 200);
  }

  void update() {
    target.x = mouseX;
    target.y = mouseY;
    target.add(offset);
    
    offset.rotate(offsetRotationSpeed);
    
    PVector vectorToTarget = PVector.sub(target, position);
    vectorToTarget.limit(MAX_SPEED);//if larget than max speed, will set magnitude to max speed

    //f = ma
    //a = f/m
    PVector steerForce = PVector.sub(vectorToTarget, velocity); 

    PVector acceleration = PVector.mult(steerForce, 1/mass);

    velocity.add(acceleration);
    position.add(velocity);


    angle = velocity.heading();
  }

  void draw() {

    noStroke();
    pushMatrix();//start transformation
    translate(position.x, position.y);//translate the origin
    rotate(angle);//rotate the origin
    rectMode(CENTER);//move where the rectangle draws
    rect(0, 0, 10, 10);
    popMatrix();//end transformation

    //ellipse(target.x, target.y, 5, 5);
  }
}
