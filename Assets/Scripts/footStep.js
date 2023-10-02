var ground : AudioClip;

private var step : boolean = true;
var audioStepLengthWalk : float = 0.45;
var audioStepLengthRun : float = 0.25;

function OnControllerColliderHit(hit : ControllerColliderHit){
	var controller : CharacterController = GetComponent(CharacterController);
	
	if(controller.isGrounded && controller.velocity.magnitude < 5 && controller.velocity.magnitude > 3 && hit.gameObject.tag == "Ground" && step == true){
		WalkOnGround();
	}

}

function WalkOnGround(){
	step = false;
	audio.clip = ground;
	audio.volume = 1;
	audio.Play();
	yield WaitForSeconds(audioStepLengthWalk);
	step = true;
}