Camera cam = new Camera();

ArrayList<PVector> points = new ArrayList<PVector>();

PVector center;
PVector offset = new PVector();
float aspect;
int cubesize = 100;
int size = 10;
float middle = -cubesize/2.0 * size;
boolean pointMode = false;
boolean prevKeySpace = false;
boolean prevKeyT = false;
float noiseScale = 30;
float threshold = .5;
boolean threshModeConstant = true;
void setup() {
  size(800, 500, P3D);


  center = new PVector(width/2, height/2);
  aspect = (float)width / (float)height;

  generateNoise3D();
}

void draw() {
  cam.update();

  background(0);
  lights();
  perspective(PI/2, aspect, 1, 10000);
  pushMatrix();
  translate(center.x, center.y);
  rotateX(map(mouseY, 0, height, -1, 1));
  rotateY(map(mouseX, 0, width, -PI, PI));
  translate(middle, middle, middle);

  if (pointMode) {
    stroke(255);
    noFill();
  } else {
    noStroke();
    fill(128);
  }

  for (PVector p : points) {
    pushMatrix();
    translate(size * p.x, size * p.y, size * p.z);
    fill(255 - 255 * p.y/cubesize);
    if (pointMode)
      point(0, 0, 0);
    else
      box(size, size, size);
    popMatrix();
  }
  popMatrix();
  perspective();
}
void generateNoise3D() {
  points.clear();

  float[][][] data = new float[cubesize][cubesize][cubesize];
  float halfCubeSize = cubesize / 2.0;

  for (int x = 0; x < cubesize; x++) {
    for (int y = 0; y < cubesize; y++) {
      for (int z = 0; z < cubesize; z++) {
        data[x][y][z] = noise((x - halfCubeSize)/noiseScale + offset.x, (y - halfCubeSize)/noiseScale + offset.y, (z - halfCubeSize)/noiseScale + offset.z);
      }
    }
  }

  int[][][] blocks = new int[cubesize][cubesize][cubesize];
  for (int x = 0; x < cubesize; x++) {
    for (int y = 0; y < cubesize; y++) {
      for (int z = 0; z < cubesize; z++) {
        float tempThreshold = threshModeConstant ? threshold : 1 - (float) y / cubesize;
        if (data[x][y][z] > tempThreshold) blocks[x][y][z] = 1;//points.add(new PVector(x, y, z));
      }
    }
  }

  for (int x = 0; x < cubesize; x++) {
    for (int y = 0; y < cubesize; y++) {
      for (int z = 0; z < cubesize; z++) {
        if (blocks[x][y][z] == 1 && !isPointHidden(blocks, x, y, z)) points.add(new PVector(x, y, z));
      }
    }
  }
}
boolean isPointHidden(int[][][] blocks, int x, int y, int z) {
  if (x <= 0) return false;
  if (y <= 0) return false;
  if (z <= 0) return false;
  if (x >= blocks.length - 1) return false;
  if (y >= blocks[x].length - 1) return false;
  if (z >= blocks[x][y].length - 1) return false;

  if (blocks[x - 1][y][z] == 0) return false;
  if (blocks[x + 1][y][z] == 0) return false;
  if (blocks[x][y - 1][z] == 0) return false;
  if (blocks[x][y + 1][z] == 0) return false;
  if (blocks[x][y][z - 1] == 0) return false;
  if (blocks[x][y][z + 1] == 0) return false;

  return true;
}

void mouseWheel(MouseEvent event) {
  noiseScale += event.getCount();
  if (noiseScale < 6) noiseScale = 6;
  generateNoise3D();
}