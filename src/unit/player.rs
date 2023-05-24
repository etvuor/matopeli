use rand::Rng;
use num_traits::NumAssign;
use std::ops::Range;
use num_traits::{NumAssign, Num};

// Define a generic Position struct
#[derive(Debug, Clone, Copy)]
pub struct Position<T> {
    pub x: T,
    pub y: T,
}

// Implement the Position trait for the generic Position struct
impl<T> Position<T> {
    pub fn position(&self) -> Position<T> {
        *self
    }
}

// Implement PartialEq for Position struct
impl<T: PartialEq> PartialEq for Position<T> {
    fn eq(&self, other: &Self) -> bool {
        self.x == other.x && self.y == other.y
    }
}

// Player struct
pub struct Player {
    pub position: Position<f64>,
    pub speed: f64,
    pub health: u32,
}

impl Player {
    pub fn new(x: f64, y: f64, speed: f64, health: u32) -> Self {
        Player {
            position: Position { x, y },
            speed,
            health,
        }
    }

    pub fn position(&self) -> Position<f64> {
        self.position
    }

    pub fn set_rand_position(&mut self, rng: &mut impl Rng, x_range: Range<f64>, y_range: Range<f64>) {
        let x = rng.gen_range(x_range);
        let y = rng.gen_range(y_range);
        self.position = Position { x, y };
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

