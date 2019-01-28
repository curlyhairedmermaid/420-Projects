void setup(){
 size(800, 500, P3D); 
}

void draw(){
  background(0);
  
  float time = millis()/1000.0;/// how many sec have passed since the start of the program
  pushMatrix();
  translate(400,250,100);
  rotateY(time);
  ///rotateX(
  box(10, 10, 10);//size of box
  popMatrix();
}
