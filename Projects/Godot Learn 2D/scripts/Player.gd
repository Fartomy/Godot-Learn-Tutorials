extends Area2D
signal hit

export var speed = 400
var screen_size

func keep_player(var vlc, var delta):
	position += vlc * delta
	position.x = clamp(position.x, 0, screen_size.x)
	position.y = clamp(position.y, 0, screen_size.y)

func player_direct(var vlc):
	if vlc.x != 0:
		$AnimatedSprite.animation = "walk"
		$AnimatedSprite.flip_v = false
		$AnimatedSprite.flip_h = vlc.x < 0
	elif vlc.y != 0:
		$AnimatedSprite.animation = "up"
		$AnimatedSprite.flip_v = vlc.y > 0

func movement(var delta):
	var velocity = Vector2.ZERO

	if Input.is_action_pressed("move_right"):
		velocity.x += 1
	if Input.is_action_pressed("move_left"):
		velocity.x -= 1
	if Input.is_action_pressed("move_down"):
		velocity.y += 1
	if Input.is_action_pressed("move_up"):
		velocity.y -= 1
	if velocity.length() > 0:
		velocity = velocity.normalized() * speed
		$AnimatedSprite.play() # It is a same this thing --> get_node("AnimatedSprite").play() --> '$' is get_node() function
	else:
		$AnimatedSprite.stop()
	keep_player(velocity, delta)
	player_direct(velocity)

func start(pos):
	position = pos
	show()
	$CollisionShape2D.disabled = false

func _ready():
	screen_size = get_viewport().size
	hide()

func _process(delta):
	movement(delta)

func _on_Player_body_entered(body):
	hide()
	emit_signal("hit")
	$CollisionShape2D.set_deferred("disabled", true)
