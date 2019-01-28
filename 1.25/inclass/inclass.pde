void setup(){
size(800,500);

}
void draw(){
  background(0);
  
  float angle = map(mouseX, 0, width, 0, 2);
  //start transformation
  pushMatrix();
  translate(100, 100);
  rotate(angle);
  rectMode(CENTER);
  rect(0,0,50,50);
  
  //end transforamtion
  popMatrix();
  rectMode(CORNER);
  rect(400, 10, 50,10);
  
}
