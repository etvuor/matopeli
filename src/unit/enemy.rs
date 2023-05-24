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

// Enemy struct
pub struct Enemy {
    pub position: Position<f64>,
    pub speed: f64,
}

impl Enemy {
    pub fn with_speed(speed: f64) -> Self {
        Enemy {
            position: Position { x: 0.0, y: 0.0 },
            speed,
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
}
