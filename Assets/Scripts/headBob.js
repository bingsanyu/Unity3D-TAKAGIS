#pragma strict

private var timer = 0.0;
var bobbingSpeed = 0.0;
var bobbingAmount = 0.1;
var midpoint = 1.0;

var waveslice = 0.0;

var ground : AudioClip;
var hasPlayed = false;

function Update () {
	var FPCSpeed = GameObject.FindGameObjectWithTag("Player").GetComponent(CharacterMotor);
	bobbingSpeed = 0.05 * FPCSpeed.headBobSpeed;

	var horizontal = Input.GetAxis("Horizontal");
	var vertival = Input.GetAxis("Vertical");
	
	if(Mathf.Abs(horizontal)==0 && Mathf.Abs(vertival)==0){
		timer = 0.0;
	}
	else{
		waveslice = Mathf.Sin(timer);
		timer = timer + bobbingSpeed;
		if(timer > Mathf.PI *2){
			timer = timer - (Mathf.PI *2);
			hasPlayed = false;
		}
	}
	
	var translateChange = waveslice * bobbingAmount;
	var totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertival);
	totalAxes = Mathf.Clamp(totalAxes,0.0,1.0);
	translateChange = totalAxes * translateChange;
	transform.localPosition.y = midpoint + translateChange;
	
	if(!hasPlayed && waveslice!=0){
		audio.clip = ground;
		audio.Play();
        hasPlayed = true;
    }
}
