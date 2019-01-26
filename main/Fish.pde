class Fish {
  float maxSpeed = 5;
  float maxForce = 10;
  float mass = 10;
  PVector position = new PVector();
  PVector velocity = new PVector();
  PVector acceleration = new PVector();
  PVector force = new PVector();
  PVector targetOffset = new PVector();
  PVector prevPosition = new PVector();
  PVector target;

//class setup
  Fish() {
    position.x = random(width);
    position.y = random(height);
    acceleration.y = random(-5, 5);
    acceleration.x = random(-2, 5);

    mass = random(10) + 5;
    maxSpeed = random(5) + 1;
    maxForce = random(2) + random(2);
    targetOffset.x = random(width);
    targetOffset.y = random(height);
    target = new PVector(random(width), random(height));
  }
//update and math logic
  void update() {

    
    PVector dir = PVector.sub(target, position); //vector to target position
    dir.add(targetOffset); // distance to targetOffset. comment out to have Agents chase target
    dir.limit(maxSpeed); // limit vector magnitude equal to maxSpeed

    PVector force = PVector.sub(dir, velocity); // calculate force by subtracting the current speed from the desired speed
    //f.limit(maxForce); // limit force to maxForce
    force.mult(.2);
    force.add(force);
    float mag = targetOffset.mag();
    float angle = targetOffset.heading();// same as atan2
    angle += .05;
    targetOffset.x = mag * cos(angle);
    targetOffset.y = mag * sin(angle);
    force.div(mass); 
    acceleration.add(force);
    velocity.add(acceleration);
    position.add(velocity);
    reset();
  }
//drawing the thing to the screen
  void draw() {
    ellipse(position.x, position.y, 25, 25);
    fill(255);
  }
  //resets the acceleration and forces so it doesn't fling itself around
  void reset(){
    force.mult(0);
    acceleration.mult(0);
  }
}
