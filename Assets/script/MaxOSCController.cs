using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityOSC;

namespace acFonts{
public class MaxOSCController : MonoBehaviour {

	int count;
	private Queue queue;
	GameObject fontGroup;
	GameObject camera;
	public bool isCamera;

	// Use this for initialization
	void Start () {
		queue = new Queue();
		queue = Queue.Synchronized(queue);
		OSCHandler.Instance.Init ();
		count = 0;
		OSCHandler.Instance.PacketReceivedEvent += OnPacketReceived;
		fontGroup = GameObject.Find ("/FontsContainer/Fonts");
		camera = GameObject.Find ("/Main Camera");
		isCamera = false;
	}
	
	// Update is called once per frame
	void Update () {
		
		while (0 < queue.Count) {
			OSCPacket packet = queue.Dequeue () as OSCPacket;
			if (packet.IsBundle ()) {
				// OSCBundleの場合
				OSCBundle bundle = packet as OSCBundle;
				foreach (OSCMessage msg in bundle.Data) {
					// メッセージの中身にあわせた処理
				}
			} else {
				// OSCMessageの場合はそのまま変換
				OSCMessage msg = packet as OSCMessage;
				// メッセージの中身にあわせた処理
				ListenToOSC();
			}
		}
	}

	void OnPacketReceived(OSCServer server, OSCPacket packet) {
		// 来たパケットをキューに積んでおく
		queue.Enqueue(packet);
	}

	void ListenToOSC(){
		OSCHandler.Instance.UpdateLogs ();
		Dictionary<string, ServerLog> servers = new Dictionary<string, ServerLog>();
		servers = OSCHandler.Instance.Servers;
		foreach (KeyValuePair<string, ServerLog> item in servers) {
			//Debug.Log (item.Value.log.Count);
			if (item.Value.log.Count > 0) {
				//Debug.Log ("count is more than zero");
				int lastPacketIndex = item.Value.packets.Count - 1;

				string s1 = item.Value.packets [lastPacketIndex-1].Data [0].ToString ();
				string s = item.Value.packets [lastPacketIndex].Data [0].ToString ();
				var address1 = item.Value.packets [lastPacketIndex - 1].Address;
				var address = item.Value.packets [lastPacketIndex].Address;
				Debug.Log (address + "/" + s);
				//s2 is knob or note number
					if (address.Contains ("knob")) {
						var rawValue = float.Parse (s);
						var value = (float.Parse (s) - 1)* 10F / 127F;
						if (address.Contains ("16")) {
							fontGroup.GetComponent<ChangeAllChildValue> ().ChangeParameter (2,value);
						} else if (address.Contains ("17")) {
							fontGroup.GetComponent<ChangeAllChildValue> ().ChangeParameter (4, value / 10F);
						}else if(address.Contains("18")){
							fontGroup.GetComponent<ChangeAllChildValue> ().ChangeParameter (5, value / 10F);

						}else if(address.Contains("19")){
							fontGroup.GetComponent<ChangeAllChildValue> ().ShowAircord (value / 10F);
						}else if (address.Contains("24")) {
							if (!isCamera) {
								fontGroup.GetComponent<ChangeAllChildValue> ().ChangeColor (value);
							} else {
								camera.GetComponent<CameraController> ().CameraMove (rawValue);
							}
						}
					
				} else if (address.Contains ("note")) {
						var value = float.Parse (s);
						if(value == 127F){
							if (isCamera) {
								isCamera = false;
								camera.GetComponent<CameraController> ().SetToDefault();
								fontGroup.GetComponent<ChangeAllChildValue> ().ChangeColor (Random.Range(0F,1F));
							} else{
								isCamera = true;
								camera.GetComponent<CameraController> ().Move();
							}
						}
				
				}
			}
		}
		OSCHandler.Instance.UpdateLogs ();
	}
}
}
