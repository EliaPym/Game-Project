/*
 * V0.3.0
 * Development on procedurally generating levels starts
 * New logo
 * Development starts on making UI better scalable
 * 0.3.1:
 * All platforms can be jumped to
 * Movement adjusted (heavier player with less jump force and movement force)
 * Scalable UI is properly implemented
 * Modified logo
 * Skybox changed to light blue
 * Cursor is hidden when resume is pressed
 * 0.3.2
 * Redesigned pause menu
 * Cursor is hidden when game started from menu
 * Level selection screen made
 * 0.3.3
 * New button images added and pause menu gradients are now visible
 * Brick texture added to platforms
 * Level Selection can be accessed and back button works. Still need to get background to change
 * 0.3.4
 * Slight adjustment to layout of main menu
 * Cursor should be shown when apropriate
 * Level selection works!
 * Pause menu now has working resume button again (pause menu was not set as target on camera)
 * Pseudocode scripts start being implemented so detect object is made in a seperate script
 * Sun position moved so the shadow is infront of player
 * Starting posiion is at origin
 * Camera is closer to monkey and the monkey is down from 0.14 to 0.1 in scale to the original model
 * Mute button works!
 * 0.3.5
 * Alien level added
 * Some changes for usability
 * 
 * 0.4.0
 * Arrows should select buttons
 * Usability is massively improved
 * Mobile controls implemented
 * New monkey model with thinner tail
 * Lots of debug messages for repsawn block script including breakdown of platforms that were incorrectly indexed
 * Modified version of main menu made for android
 * Level selection screen modified for android
 * Random updates to demo so it uses new movement and sun goes round
 * "Main Game" gets new movement working and new camera angle for no reason
 * New songs added (will be improved in later versions)
 * Movement changed so that the velocity will not be changed when the magnitude goes above 200
 * Lighting changed to be a white light instead of skybox to improve performance
 * 0.4.1
 * Lighting changed back to skybox as it looks much better
 * Auto-respawn added as well as settings page
 * Removed unknown script from camera and sun
 * Turned off MSAA on camera as it was unavailable
 * Monkey tail colour changed
 * 0.4.2
 * Lava level given skybox to be used after levels are remade
 * Level can be played in selection menu
 * Coin respawns when hit
 * Last played level will be seleced in level menu
 * Notice about levels being incomplete put back on screen and colour changed
 * Pause panel in alternative mode given gold material
 * Alternative mode sun cycle increased
 * Monkey ears and tail now pink like the original 0.2 model
 * Deleted loads of old images for UI
 * 0.4.3
 * Drag factor decreased to 16 from 18
 * Position of sun moved infront of player so the front of the blocks can be more easily identified from the top
 * Easy path material made metallic so effect described above can be made
 * Graphics settings changed to be more appropriate
 * Stopped blocks from spawning below void level
 * Settings button moved to top left and rotated
 * Terrain and aura lighting removed
 * Unusable MOAJ video removed from canvas
 * Fade image removed
 * Alien level now has preview saved
 * Classic level added
 * 0.4.4
 * The "Random" attribute in respawn blocks will make repsawning random to be less confusing
 * Crossings made and will respawn as not random
 * Polemer song added to classic level
 * An old backup versin of demo added to levels
 * Scroll bar for level selection now supports going off screen better
 * Demo changed to look more like 0.2 version
 * 0.4.5
 * Coin counter added
 * Power-Ups ACTIVATED!
 * Max speed decreased from 120 to 100
 * Mid air spawner fixed
 * 0.4.5.1
 * Propper images added to splash screen
 * Camera angles fixed for classic mode
 * New SlowUpdate made for respawn block using invoke repeating
 * Added slow update to midair respawn
 * Coin counter stays in top left
 * FPS counter added
 * Added explanation to demo level and made physics more like 0.2
 * Gold material changed to better suit the death screen
 * Removed level preview script from settings
 * Settings button rotates
 * Made Main menu skybox not use lights
 * Medium graphics will have better shadows
 * 0.4.5.2
 * Collider deactivated on collectables to stop them pushing player
 * Fixed camera angle not being able to set to current by displaying current straight away
 * Deactivated "Nothing" toggle in settings
 * Put level menu back to normal skybox and made it rotate
 * Settings skybox also rotates
 * Level menu is now laoded async so skybox rotates more smoothly when switching scenes
 * Upgraded unity from 2019 8.2.1 to 2019 3.3 (looks a bit weird)
 * Changed to unity version 2 assets because of above
 * Fixed gui not sticking to top left
 * FPS display can be toggled in settings
 * 0.4.5.3
 * Large notice added for clients about levels
 * Alternative mode text hidden
 * 
 * 0.5.0
 * Graphics Settings added
 * Need to fix auto respawn setting
 * Multiple unused images removed and new logo added
 * Disabled logo randomiser
 * Hid levels warning
 * New skybox added and rotation reduced to 3.5 from 5
 * Level and quit buttons moved slightly
 * Settings button roates slower
 * Size of coins halved
 * Power up model made
 * Mid air spawn doesn't check velocity only OnTriggerEnter
 * Random removed from mid-air respawn MUST NOTE                      ***********
 * Coin lighting made more orange and baked. Only one light per coin to reduce lag
 * Classic level message changed to say only gamer can complete
 * Drag changed to 13 from 16
 * Settings cleaned up a bit, scroll view added and controls label added
 * Audio sounds effects added
 * Friction of blocks reduced massivley
 * Coin and power ups are graphically demanding ???
 * Crashing due to respawn block script fixed
 * Minimap partially added
 * Traps implemented
 * Atmosphere image used as cubemap for reflections
 * Number of blocks increased by two per path and crossing now respawn 80 units ahead instead of 50
 * Minimap almost properly implemented
 * Pause menu font size changed from 24 to 30
 * Fullscreen setting added but not tested
 * 0.5.1
 * Fullscreen should now work
 * Factory level can now be played in build
 * Continuous audio added using preloader scene
 * Background removed from minimap
 * Air jump added along with spin
 * 0.5.2
 * Credits added
 * New cursor added
 * Minimap background changed
 * Minimap stays in top right
 * Respawn now activates respawn procedure
 * Mid air jump can only be done once
 * Rotation script now uses time.deltatime *100
 * Chapter 3 started to be added
 * 0.5.3
 * UI on settings page now works better with resizing
 * Gem material needs fixing back
 * SpinRotation affects how many times the rotation is repeated so the monkey always ends in the same position
 * Coin size increased and hitbox increased further
 * Drag reduced and max speed reduced
 * Reference to Big Monkey coroutine removed
 * Binary level updated and new skybox added
 * Power up icon added
 * Highscore saving system partially implemented
 * Mid-air objects spawn further away
 * 0.5.4
 * Non-random respawn block used for crossings will now spawn further away
 * Power up icon sticks to top of screen
 * Respawn block's slow update has 0.5 s instead of 1 second delay
 * ColourSpace set to linear instead of gamma so colour grading can be used
 * Colour Grading added to atmosphere level
 * Colour grading and bloom added to lava level
 * Spin on double jump disabled for classic level
 * Classic now has atmosphere colour graing and perspective camera
 * Broken highscore code commented out temporarily
 * 10-bit HDR enabled
 * Lava minimap colour changed
 * Void level of parkour changed
 * Parkour level gets fx and a floor to look more like a city
 * Non-random block respawn now keeps y position constant (doesn't change it to 7)
 * Chromatic aberration added to main menu
 * 0.5.5
 * Polemer track will now play in binary and alien levels
 * Alien level gets a ... visual upgrade and smoothspeed of camera reduced
 * Android main menu updated
 * Android main menu should now be shown on android
 * Horizontal movement can be made by swiping and deadzone added
 * Jump changed to tap
 * Infinite jumping stopped
 * New logo added to android
 * Music for Alien changed to Realisation
 * Joystick support added but removed as it changed standard movement
 * Force Y limited to 2* Jump Force
 */