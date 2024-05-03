extends RigidBody2D



func random_anim():
	$AnimatedSprite.playing = true
	var mob_types = $AnimatedSprite.frames.get_animation_names()
	$AnimatedSprite.animation = mob_types[randi() % mob_types.size()]

func _ready():
	random_anim()

#func _process(delta):
#	pass


func _on_VisibilityNotifier2D_screen_exited():
	queue_free()
