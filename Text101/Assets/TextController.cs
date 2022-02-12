using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TextController : MonoBehaviour {

	// Use this for initialization
	public Text test;
	private enum State{cell,cell_mirror,cell_sheet,mirror,cell_mir_shet,sheet,lock_0,sheet_1,lock_1_stl,lock_1_kl,lock_fnl,es_grd,es_pr,kl_m,lock_o_kl_m,lock_1_kl_s,f_kl_sh,wait1,wait2,wait3,wait4,wait5,wait6,wait7,wait8};
	private State mystate;
	int s=0;
	int x=0;
	void Start () {
	mystate = State.cell;
	
	}
	
	// Update is called once per frame
	void Update () {
		if 		(mystate == State.cell) {state_cell();}
		else if (mystate == State.sheet) {state_sheet();}
		else if (mystate == State.mirror) {state_mirror();}
		else if (mystate == State.cell_sheet) {state_cell_sheet();}
		else if (mystate == State.cell_mirror) {state_cell_mirror();}
		else if (mystate == State.lock_fnl) {state_lock_fnl();}
		else if (mystate == State.lock_o_kl_m) {state_c_kl_m();}
		else if (mystate ==State.kl_m) {state_kl_m();}
		else if (mystate==State.lock_1_kl_s) {state_l_kl_sh();}
		else if (mystate==State.f_kl_sh) {state_f_kl_sh();}
		else if (mystate ==State.lock_1_stl){state_stl();}
		else if (mystate ==State.lock_0){state_lock();}
		else if (mystate ==State.es_pr){es_pr();}
		else if (mystate ==State.es_grd){es_grd();}
		else if (mystate ==State.wait1){wait_1();}
		else if (mystate ==State.wait2){wait_2();}		
		else if (mystate ==State.wait3){wait_3();}
		else if (mystate ==State.wait4){wait_4();}		
		else if (mystate ==State.wait5){wait_5();}
		else if (mystate ==State.wait6){wait_6();}
		else if (mystate ==State.wait7){wait_7();}
		else if (mystate ==State.wait8){fnl_wait();}
	}
	void state_cell(){
		test.text="You're in a prison cell, and you want to escape. There are some dirty sheets on the bed, a mirror on the wall, and the door is locked from the outside.\n\n Press S to view Sheets,\n M to view Mirror,\n L to view Lock";
		if (Input.GetKeyDown(KeyCode.S)) {mystate =State.sheet;}
		else if (Input.GetKeyDown(KeyCode.M)) {mystate =State.mirror;}
		else if (Input.GetKeyDown(KeyCode.L)) {mystate =State.lock_0;}	
	}
	void state_sheet(){
		test.text=" I can't believe I sleep on those things, maybe I could use it later.\n\n Press T to take sheet, R to return";
		if (Input.GetKeyDown(KeyCode.T)&& s==0) {mystate =State.cell_sheet;
		s=s+1;}
		else if (Input.GetKeyDown(KeyCode.R)&& s==0) {mystate =State.cell;}
		else if(Input.GetKeyDown(KeyCode.T)&& s==1) 
		{ test.text="Maybe I could use this to get rid of the guard\n\n Press T to take sheet, R to return...";
			if (Input.GetKeyDown(KeyCode.T)) {mystate =State.lock_fnl;}
			else if (Input.GetKeyDown(KeyCode.R)&& s==1) {mystate =State.cell_mirror;}
		}
		}
	void state_mirror(){
	if (s==1)
	{
	test.text="I can't do anything with the mirror....the guard might suspect me...Press R to return...";
	 if (Input.GetKeyDown(KeyCode.R)) {mystate =State.cell_sheet; s++;}
	}
	else
	{
		test.text="Wow, there is a....mirror....an actual mirror...Maybe I could break it and use its shard for something....\n\n Press B to break mirror , R to return ";
		if (Input.GetKeyDown(KeyCode.B)&& s==0) {mystate =State.cell_mirror;
			s=s+1;}	
		else if (Input.GetKeyDown(KeyCode.R)) {mystate =State.cell;}
	}
	
	}
	void state_cell_mirror(){
	test.text=" Well...Hello...*sigh*..There is a guard on my door ...oh... he has the keys...Maybe I could steal them....or....\n\n Press S to steal the keys, V to view sheet , K to kill the guard with the shard"; 
		if (Input.GetKeyDown(KeyCode.K)) {mystate =State.lock_o_kl_m;}	
			else if (Input.GetKeyDown(KeyCode.V)) {mystate =State.sheet;}
	else if (Input.GetKeyDown(KeyCode.S)) {mystate =State.lock_1_stl;}
	if (Input.GetKeyDown(KeyCode.K)) {mystate =State.lock_o_kl_m;}	
	}
	void state_cell_sheet(){
		test.text=" Ok...I got the sheet..maybe I could try and....There is a guard on my door ...oh... he has the keys...Maybe I could steal them....or....\n\n Press S to steal the keys, V to view mirror , K to kill the guard with the sheet"; 
		if (Input.GetKeyDown(KeyCode.K)) {mystate =State.lock_1_kl_s;}
		else if (Input.GetKeyDown(KeyCode.V)&& !(s==2)) {mystate =State.mirror;}
		else if (Input.GetKeyDown(KeyCode.S)) {mystate =State.lock_1_stl;}
		}	
	void state_lock_fnl(){
	test.text="I need to get the keys to escape my cell....\n\n Press S to steal the keys, K to kill the guard with the shard, L to kill the guard with the sheet";
		if (Input.GetKeyDown(KeyCode.K)) {mystate =State.lock_o_kl_m;}
		else if (Input.GetKeyDown(KeyCode.S)) {mystate =State.lock_1_stl;}
		else if (Input.GetKeyDown(KeyCode.L)) {mystate=State.lock_1_kl_s;}	
	}
	void state_c_kl_m(){
		test.text="Crap...I need to get the body inside...Quick..*CLICK*...Door opened.... /n/n Press C to cover body with sheet, L to leave...";
		if(Input.GetKeyDown(KeyCode.C) ||Input.GetKeyDown(KeyCode.L))
		{
		mystate=State.kl_m;
		}
	}
	void state_kl_m(){
		test.text=" OH..SH....There's blood everywhere..I need to get the heck out of here... Maybe I should take his clothes \n\n Press W to wear guard's clothes covered with blood, E to Escape the Cell";
		if (Input.GetKeyDown(KeyCode.W)) {mystate =State.es_grd;}
		else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}	
	}
	void state_l_kl_sh(){
	test.text="Alright...Door opened......body in .....\n\nPress C to cover body with sheet,E to escape anyway...";
		if (Input.GetKeyDown(KeyCode.C)||Input.GetKeyDown(KeyCode.E)) {mystate =State.f_kl_sh;}
		
       		}
	void state_f_kl_sh(){
		test.text=" WAIT....... Maybe I should take his clothes \n\n Press W to wear guard's clothes , E to Escape the Cell";
		if (Input.GetKeyDown(KeyCode.W)) {mystate =State.es_grd;}
		else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}	
	}
	void state_stl(){
	if(x==0){
			test.text=" ......1.....2.....SHII......1.......2........ Okay ....Got 'em.....No one is around...\n\nPress E to Escape, W to Wait";
		if (Input.GetKeyDown(KeyCode.W)&& x==0) {mystate =State.wait1;}
			else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}
		}
		else
		{
		test.text="NOO MORE WAITING JUST LET ME F@&%#ng GOO PRESS E NO W";
		if (Input.GetKeyDown(KeyCode.W)&& x==1) {mystate =State.wait8;}
		else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}
		}	
	}
	void es_pr(){
		test.text="You Escaped as A Prisoner\n\nTo Be Continued....\n Press Enter to play again...";
	if (Input.GetKeyDown(KeyCode.Return))
		{mystate =State.cell; s=0;}
	}
	void es_grd(){
		test.text="You Escaped as A Guard...I wanna know how's that gonna turn out\n\nTo Be Continued.... \nPress Enter to play again...";
		if (Input.GetKeyDown(KeyCode.Return))
		{mystate =State.cell;s=0;}
	}
	void state_lock(){
		test.text="Nothing Here..................\n\nPress R to Return...";
		if (Input.GetKeyDown(KeyCode.R)) {mystate =State.cell;}
		
	}
	void wait_1(){
		test.text="Probably a good idea to wait....I can't see anyone...I should leave now ........\n\n Press E to Escape, W to Wait";
		if (Input.GetKeyDown(KeyCode.W)) {mystate =State.wait2;}
		else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}	
	}
	void wait_2(){
		test.text="AAAAMMMMMMMMMMMMMM.............................ok.. a ... y ......... \n\nPress E to Escape, W to Wait ";
		if (Input.GetKeyDown(KeyCode.W)) {mystate =State.wait3;}
		else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}
		}
	void wait_3(){
		test.text="...................................... \n\nPress E to Escape, W to Wait ";
			if (Input.GetKeyDown(KeyCode.W)) {mystate =State.wait4;}
			else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}	
			}
	void wait_4(){
		test.text="You don't want me to escape , Dont YA ..\n\nPress Y for Yes, E to let me escape ........ I prefer that you press E ..plz ";
		if (Input.GetKeyDown(KeyCode.Y)) {mystate =State.wait5;}
		else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}
		}
		
	void wait_5(){
		test.text="Listen Man , I have a family..I want to see them ... its been years ...please ...\n\n Press E to let me go , W to Wait.....Press E..... plz    ";
		if (Input.GetKeyDown(KeyCode.W)) {mystate =State.wait6;}
		else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}
		}
		void wait_6(){
		test.text="OKAY.... fine ..I don't have a family....just\n\n Press E to let me ok ...Don't Press W .. Don't ...";
			if (Input.GetKeyDown(KeyCode.W)) {mystate =State.wait7;}
			else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}
			}
	void wait_7(){
		test.text="You Know ... I do have some power...You don't always control the game ......  I could just hack your computer right....but ... I dont know how.. Let Me Goooo...plz...\n\nPress E to let me go , W to Wait ";
		if (Input.GetKeyDown(KeyCode.W)) {mystate =State.wait8;}
		else if (Input.GetKeyDown(KeyCode.E)) {mystate =State.es_pr;}
	}
	void fnl_wait(){
	test.text="                    YOU LOST\n     Prisoner Killed Himself ........... \n\nPress P to play again........";
	
		if (Input.GetKeyDown(KeyCode.P)) {mystate =State.cell;x=x+1;s=0;}
	}
}


