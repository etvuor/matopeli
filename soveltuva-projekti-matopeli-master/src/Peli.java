import java.awt.Color;
import java.awt.Graphics;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.KeyEvent;
import java.awt.event.KeyListener;
import java.util.Random;
import java.awt.Font;

import javax.swing.ImageIcon;
import javax.swing.JPanel;
import javax.swing.Timer;

public class Peli extends JPanel implements KeyListener, ActionListener{
	
	

	private int[] madonpituusX = new int[750];
	private int[] madonpituusY = new int[750];

	private boolean left = false;
	private boolean right = false;
	private boolean up = false;
	private boolean down = false;

	private ImageIcon snakeheadright2;
	private ImageIcon snakeheadleft2;
	private ImageIcon snakeheadup2;
	private ImageIcon snakeheaddown2;

	private int lengthofsnake=3;

	private Timer timer;
	private int delay = 100;
	private ImageIcon snakebody2;	//vartalon kuva k‰‰rmeest‰ = snakebody2.png
	
	private int [] enemyposX={25,50,75,100,125,150,175,200,225,
			250,275,300,325,350,375,400,425,450,500,525,550,575,600,625,
			650,675,700,725,750,775,800,825,850};
	
	private int [] enemyposY={75,100,125,150,175,
			200,225,250,275,300,325,350,375,400,425,450,475,500,
			525,550,575,600,625};
	
	private ImageIcon enemyimage;
	

	private Random random = new Random();
	
	private int score = 0;
	
	private int posX = random.nextInt(34);
	private int posY = random.nextInt(23);
	
	
	
	private int moves = 0;
	
	private ImageIcon title;

	public Peli(){
		addKeyListener(this);
		setFocusable(true);
		setFocusTraversalKeysEnabled(false);
		timer = new Timer(delay, this);
		timer.start();
	}

	
	public void paint(Graphics g) {
		if (moves == 0){
			madonpituusX[2]=50;
			madonpituusX[1]=75;
			madonpituusX[0]=100;
				
			madonpituusY[2]=100;
			madonpituusY[1]=100;
			madonpituusY[0]=100;
		}
		
		//draw border for the title
		g.setColor(Color.WHITE);
		g.drawRect(24, 10, 851, 55);
		
		//draw title
		title = new ImageIcon("snaketitle4.png");
		title.paintIcon(this, g, 25, 11);
		
		//draw border
		g.setColor(Color.WHITE);
		g.drawRect(24, 74, 851, 577);
		
		//draw background
		g.setColor(Color.black);
		g.fillRect(25, 75, 850, 575);
		
		//scores
		g.setColor(Color.RED);
		g.setFont(new Font("Arial", Font.PLAIN, 14));
		g.drawString("Score: "+score, 780, 30);
		
		
		snakeheadright2 = new ImageIcon ("snakeheadright2.png");
		snakeheadright2.paintIcon(this,g,madonpituusX[0],madonpituusY[0]);
		for (int a = 0; a<lengthofsnake; a++)
		{
			if (a==0 && right){
				snakeheadright2 = new ImageIcon ("snakeheadright2.png");
				snakeheadright2.paintIcon(this,g,madonpituusX[a],madonpituusY[a]);
			}
			if (a==0 && left){
				snakeheadleft2 = new ImageIcon ("snakeheadleft2.png");
				snakeheadleft2.paintIcon(this,g,madonpituusX[a],madonpituusY[a]);
			}
			if (a==0 && down){
				snakeheaddown2 = new ImageIcon ("snakeheaddown2.png");
				snakeheaddown2.paintIcon(this,g,madonpituusX[a],madonpituusY[a]);
			}
			if (a==0 && up){
				snakeheadup2 = new ImageIcon ("snakeheadup2.png");
				snakeheadup2.paintIcon(this,g,madonpituusX[a],madonpituusY[a]);
			}
			if(a!=0){
				snakebody2 = new ImageIcon ("Snakebody2.png");
				snakebody2.paintIcon(this,g,madonpituusX[a],madonpituusY[a]);
		
			}
		}
		
		enemyimage = new ImageIcon("snakestar2.png");
		
		if ((enemyposX[posX] == madonpituusX[0] && enemyposY[posY] == madonpituusY[0])){
			score++;
			lengthofsnake++;
			posX=random.nextInt(34);
			posY=random.nextInt(23);
		}
		
		enemyimage.paintIcon (this, g, enemyposX[posX], enemyposY[posY]);
		
		
		for (int b = 1; b<lengthofsnake; b++){
			if (madonpituusX[b] == madonpituusX[0] && madonpituusY[b] == madonpituusY[0]){
				right = false;
				left = false;
				up = false;
				down = false;
				
				g.setColor(Color.white);
				g.setFont(new Font("arial", Font.BOLD, 50));
				g.drawString("GAME OVER", 300,300);
				
				g.setFont(new Font("arial", Font.BOLD, 20));
				g.drawString("Press space to play again", 350,340);
				}
		
		}
		g.dispose();
	}


	@Override
	public void actionPerformed(ActionEvent e) {
		timer.start();
		if(right) {
			for(int r = lengthofsnake-1; r>=0; r--) {
				madonpituusY[r+1] = madonpituusY[r];
			}
			for(int r = lengthofsnake; r>=0; r--) {
				if(r==0) {
					madonpituusX[r] = madonpituusX[r] + 25;
				}
				else {
					madonpituusX[r] = madonpituusX[r-1];
				}
				if(madonpituusX[r] > 850) {
					madonpituusX[r] = 25;
				}
			}
			
			repaint();
		}
		if(left) {
			for(int r = lengthofsnake-1; r>=0; r--) {
				madonpituusY[r+1] = madonpituusY[r];
			}
			for(int r = lengthofsnake; r>=0; r--) {
				if(r==0) {
					madonpituusX[r] = madonpituusX[r] - 25;
				}
				else {
					madonpituusX[r] = madonpituusX[r-1];
				}
				if(madonpituusX[r] < 25) {
					madonpituusX[r] = 850;
				}
			}
			
			repaint();
		}
		if(up) {
			for(int r = lengthofsnake-1; r>=0; r--) {
				madonpituusX[r+1] = madonpituusX[r];
			}
			for(int r = lengthofsnake; r>=0; r--) {
				if(r==0) {
					madonpituusY[r] = madonpituusY[r] - 25;
				}
				else {
					madonpituusY[r] = madonpituusY[r-1];
				}
				if(madonpituusY[r] < 75) {
					madonpituusY[r] = 625;
				}
			}
			
			repaint();
		}
		if(down) {
			for(int r = lengthofsnake-1; r>=0; r--) {
				madonpituusX[r+1] = madonpituusX[r];
			}
			for(int r = lengthofsnake; r>=0; r--) {
				if(r==0) {
					madonpituusY[r] = madonpituusY[r] + 25;
				}
				else {
					madonpituusY[r] = madonpituusY[r-1];
				}
				if(madonpituusY[r] > 625) {
					madonpituusY[r] = 75;
				}
			}
			
			repaint();
		}

	}


	@Override
	public void keyPressed(KeyEvent e) {
		if(e.getKeyCode() == KeyEvent.VK_SPACE) {
			moves = 0;
			score = 0;
			lengthofsnake = 3;
			repaint();
		}
		if(e.getKeyCode() == KeyEvent.VK_RIGHT) {
			moves++;
			right = true;
			if(!left) {
				right = true;
			}
			else {
				right = false;
				left = true;
			}
			
			up = false;
			down = false;
		
		}
		
		if(e.getKeyCode() == KeyEvent.VK_LEFT) {
			moves++;
			left = true;
			if(!right) {
				left = true;
			}
			else {
				left = false;
				right = true;
			}
			
			up = false;
			down = false;
		
		}	
		
		if(e.getKeyCode() == KeyEvent.VK_UP) {
			moves++;
			up = true;
			if(!down) {
				up = true;
			}
			else {
				up = false;
				down = true;
			}
			
			left = false;
			right = false;
		
		}	
		
		if(e.getKeyCode() == KeyEvent.VK_DOWN) {
			moves++;
			down = true;
			if(!up) {
				down = true;
			}
			else {
				down = false;
				up = true;
			}
			
			left = false;
			right = false;
		
		}	
		}
	


	@Override
	public void keyReleased(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}


	@Override
	public void keyTyped(KeyEvent e) {
		// TODO Auto-generated method stub
		
	}

		
}

