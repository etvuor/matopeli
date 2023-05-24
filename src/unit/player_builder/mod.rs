use crate::unit::player::Player;
use crate::unit::player::position as player;

pub struct PlayerBuilder {
    health: u32,
    position: (u32, u32),
}

impl PlayerBuilder {
    pub fn new() -> Self {
        PlayerBuilder {
            health: 100,
            position: (0, 0),
        }
    }

    pub fn health(&mut self, health: u32) -> &mut Self {
        self.health = health;
        self
    }

    pub fn position(&mut self, position: (u32, u32)) -> &mut Self {
        self.position = position;
        self
    }

    pub fn build(&self) -> Player<f64> {
        Player::new(
            self.health,
            player::Position::new(self.position.0.into(), self.position.1.into()),
        )
    }
}


