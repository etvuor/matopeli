#[derive(Default)]
pub struct Player {
    pub speed: f64,
    pub health: u32,
}

impl Player {
    pub fn new() -> Self {
        Self {
            speed: 0.0,
            health: 0,
        }
    }

    pub fn is_alive(&self) -> bool {
        self.health > 0
    }

    pub fn take_damage(&mut self, damage: u32) {
        if damage >= self.health {
            self.health = 0;
        } else {
            self.health -= damage;
        }
    }

    pub fn health(&self) -> u32 {
        self.health
    }

    pub fn speed(&self) -> f64 {
        self.speed
    }
}


