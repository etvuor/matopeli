import java.awt.Color;

import javax.swing.JFrame;

public class Main {

	public static void main(String[] args) {
		JFrame obj = new JFrame();
		Peli peli = new Peli();
		obj.setBounds(10, 10, 905, 700);
		obj.setBackground(Color.LIGHT_GRAY);
		obj.setVisible(true);
		obj.setResizable(false);
		obj.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		obj.add(peli);
	}

}
