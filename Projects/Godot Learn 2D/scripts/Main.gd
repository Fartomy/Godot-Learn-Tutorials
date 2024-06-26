extends Node

export(PackedScene) var mob_scene
var score

func _ready():
	randomize()

func game_over():
	$Scoretimer.stop()
	$MobTimer.stop()
	$HUD.show_game_over()
	$Music.stop()
	$DeathSound.play()

func new_game():
	score = 0
	$HUD.close_hud_icon()
	$Music.play()
	$Player.start($StartPosition.position)
	$StartTimer.start()
	$HUD.update_score(score)
	$HUD.show_message("Get Ready?")
	get_tree().call_group("mobs", "queue free")

func _on_MobTimer_timeout():
	var mob = mob_scene.instance()
	var mob_spawn_location = get_node("MobPath/MobSpawnLocation")
	mob_spawn_location.offset = randi()
	var direction = mob_spawn_location.rotation * PI / 2
	mob.position = mob_spawn_location.position
	direction += rand_range(-PI / 10, PI / 2)
	mob.rotation = direction
	var velocity = Vector2(rand_range(450.0, 500.0), 0.0)
	mob.linear_velocity = velocity.rotated(direction)
	add_child(mob)

func _on_Scoretimer_timeout():
	score += 1
	$HUD.update_score(score)


func _on_StartTimer_timeout():
	$Scoretimer.start()
	$MobTimer.start()
