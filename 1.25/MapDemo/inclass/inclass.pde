
ArrayList<Boid> boids = new ArrayList<Boid>();

void setup() {
  size(800, 500);


  for (int i = 0; i < 500; i++) {
    boids.add(new Boid() );
  }
}
void draw() {
  background(0);

  for (Boid b : boids) {
    b.update();
    b.draw();
  }
}
