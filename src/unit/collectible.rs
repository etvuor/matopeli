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

// Collectible struct
#[derive(Default)]
pub struct Collectible {
    pub position: Position<u32>,
}

impl Collectible {
    pub fn new(x: u32, y: u32) -> Self {
        Collectible {
            position: Position { x, y },
        }
    }

    pub fn position(&self) -> Position<u32> {
        self.position
    }

    pub fn set_rand_position(&mut self, rng: &mut impl Rng, x_range: Range<u32>, y_range: Range<u32>) {
        let x = rng.gen_range(x_range);
        let y = rng.gen_range(y_range);
        self.position = Position { x, y };
    }
}
