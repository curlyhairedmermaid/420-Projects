ArrayList<Fish> fish = new ArrayList<Fish>();

void setup() {
  size(800, 400);
  for(int i = 0; i < 20; i ++) fish.add(new Fish()); 
}
void draw() {
  background(0);
  for(Fish f : fish){
    f.update();
    f.draw();
  }
}
