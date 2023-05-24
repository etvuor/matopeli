use super::Player;

pub struct PlayerBuilder {
    health: u8,
    speed: f64,
    position: (u32, u32),  // Add the position field of type (u32, u32)
}

impl PlayerBuilder {
    pub fn new() -> Self {
        Self {
            health: 100,
            speed: 1.0,
            position: (0, 0),  // Set the initial position
        }
    }

    pub fn health(mut self, health: u8) -> Self {
        self.health = health;
        self
    }

    pub fn speed(mut self, speed: f64) -> Self {
        self.speed = speed;
        self
    }

    pub fn position(mut self, position: (u32, u32)) -> Self {
        self.position = position;
        self
    }

    pub fn build(self) -> Player {
        Player {
            health: self.health,
            speed: self.speed,
            position: self.position,
        }
    }
}

