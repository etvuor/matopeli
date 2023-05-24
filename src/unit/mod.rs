pub mod player;
pub mod collectible;
pub mod enemy;
pub mod wall;
pub mod player_builder; // Update this line

pub use player::Player;
pub use collectible::Collectible;
pub use enemy::Enemy;
pub use wall::Wall;
pub use player_builder::PlayerBuilder; // Add this line
