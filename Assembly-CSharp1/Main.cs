using System;
using System.Threading;
using UnityEngine;

// Token: 0x02000004 RID: 4
public class Main : MonoBehaviour
{
	// Token: 0x06000022 RID: 34 RVA: 0x00002518 File Offset: 0x00000718
	private void Start()
	{
		if (!Main.started)
		{
			if (Thread.CurrentThread.Name != "Main")
			{
				Thread.CurrentThread.Name = "Main";
			}
			Main.mainThreadName = Thread.CurrentThread.Name;
			Main.isPC = true;
			Main.started = true;
			Main.level = Rms.loadRMSInt("levelScreenKN");
			if (Main.level == 1)
			{
				Screen.SetResolution(480, 320, false);
			}
			else
			{
				Screen.SetResolution(1024, 600, false);
			}
		}
	}

	// Token: 0x06000023 RID: 35 RVA: 0x000025B4 File Offset: 0x000007B4
	public void creatMiniMap()
	{
	}

	// Token: 0x06000024 RID: 36 RVA: 0x000025B8 File Offset: 0x000007B8
	public static void setBackupIcloud(string path)
	{
	}

	// Token: 0x06000025 RID: 37 RVA: 0x000025BC File Offset: 0x000007BC
	public void init()
	{
		CRes.init();
		MainObject.init();
		Player.init0();
	}

	// Token: 0x06000026 RID: 38 RVA: 0x000025D0 File Offset: 0x000007D0
	private void OnGUI()
	{
		if (this.cout < 10)
		{
			return;
		}
		this.checkInput();
		Session_ME.update();
		if (Event.current.type.Equals(EventType.Repaint))
		{
			TemMidlet.temCanvas.paint(Main.g);
			Main.g.reset();
		}
	}

	// Token: 0x06000027 RID: 39 RVA: 0x00002630 File Offset: 0x00000830
	public static void closeKeyBoard()
	{
		if (global::TouchScreenKeyboard.visible)
		{
			TField.kb.active = false;
			TField.kb = null;
		}
	}

	// Token: 0x06000028 RID: 40 RVA: 0x00002650 File Offset: 0x00000850
	public void doClearRMS()
	{
		sbyte[] array = CRes.loadRMS("versionGame");
		if (array != null)
		{
			try
			{
				LoginScreen.loadVersionGame();
			}
			catch (Exception ex)
			{
				Cout.Log(" Loi Tai !!! : " + ex.ToString());
			}
		}
		if (!Main.isPC)
		{
			return;
		}
		int num = Rms.loadRMSInt("lastZoomlevel");
		if (num != mGraphics.zoomLevel)
		{
			Rms.deleteAllRecord();
			Rms.saveRMSInt("lastZoomlevel", mGraphics.zoomLevel);
			Rms.saveRMSInt("levelScreenKN", Main.level);
		}
	}

	// Token: 0x06000029 RID: 41 RVA: 0x000026F4 File Offset: 0x000008F4
	private void FixedUpdate()
	{
		Rms.update();
		this.cout++;
		if (this.cout < 10)
		{
			return;
		}
		if (!this.isRun)
		{
			this.isRun = true;
			Screen.orientation = ScreenOrientation.LandscapeLeft;
			Application.runInBackground = true;
			Application.targetFrameRate = 30;
			base.useGUILayout = false;
			Main.isCompactDevice = Main.detectCompactDevice();
			if (Main.main == null)
			{
				Main.main = this;
			}
			ScaleGUI.initScaleGUI();
			Main.IMEI = SystemInfo.deviceUniqueIdentifier;
			Main.isIPhone = !Main.isPC;
			Main.isWP8 = false;
			if (iPhoneSettings.generation == iPhoneGeneration.iPadUnknown)
			{
				Main.isIpad = true;
			}
			int num = (int)Main.IPHONE_JB;
			if (Main.isPC)
			{
				Screen.fullScreen = false;
			}
			if (Main.isWindowsPhone)
			{
				num = 5;
			}
			if (Main.isPC)
			{
				num = 4;
			}
			if (Main.IphoneVersionApp)
			{
				num = 3;
			}
			TemMidlet.DIVICE = (sbyte)num;
			Debug.Log("typeClient :" + TemMidlet.DIVICE);
			if (iPhoneSettings.generation == iPhoneGeneration.iPodTouch4Gen)
			{
				Main.isIpod = true;
			}
			if (iPhoneSettings.generation == iPhoneGeneration.iPhone4)
			{
				Main.isIphone4 = true;
			}
			this.init();
			Main.g = new mGraphics();
			Main.g.CreateLineMaterial();
			Main.tMidlet = new TemMidlet();
			if (mGraphics.zoomLevel == 1 && !Main.isWindowsPhone)
			{
				Main.isSprite = false;
			}
			if (Main.isPC)
			{
				PaintInfoGameScreen.isLevelPoint = true;
			}
		}
		Load_Data_And_Img.load.run();
		ipKeyboard.update();
		TemMidlet.temCanvas.update();
		Image.update();
		DataInputStream.update();
		SMS.update();
		Net.update();
		if (GameCanvas.saveImage != null)
		{
			GameCanvas.saveImage.run();
		}
		if (CRes.load != null)
		{
			CRes.load.run();
		}
		if (!Main.isPC)
		{
			int num2 = 1 / Main.a;
		}
	}

	// Token: 0x0600002A RID: 42 RVA: 0x000028E4 File Offset: 0x00000AE4
	private void Update()
	{
	}

	// Token: 0x0600002B RID: 43 RVA: 0x000028E8 File Offset: 0x00000AE8
	private static void CreateLineMaterial()
	{
		if (!Main.lineMaterial)
		{
			Main.lineMaterial = new Material("Shader \"Lines/Colored Blended\" {SubShader { Pass {     Blend SrcAlpha OneMinusSrcAlpha     ZWrite Off Cull Off Fog { Mode Off }     BindChannels {      Bind \"vertex\", vertex Bind \"color\", color }} } }");
			Main.lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			Main.lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	// Token: 0x0600002C RID: 44 RVA: 0x00002928 File Offset: 0x00000B28
	private void checkInput()
	{
		if (Input.GetMouseButtonDown(0))
		{
			Vector3 mousePosition = Input.mousePosition;
			TemMidlet.temCanvas.pointerPressed((int)mousePosition.x, (int)((float)Screen.height - mousePosition.y) + mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
			this.lastMousePos.x = mousePosition.x;
			this.lastMousePos.y = mousePosition.y + (float)(mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
		}
		if (Input.GetMouseButton(0))
		{
			Vector3 mousePosition2 = Input.mousePosition;
			TemMidlet.temCanvas.pointerDragged((int)mousePosition2.x, (int)((float)Screen.height - mousePosition2.y) + mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
			this.lastMousePos.x = mousePosition2.x;
			this.lastMousePos.y = mousePosition2.y + (float)(mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
		}
		if (Input.GetMouseButtonUp(0))
		{
			Vector3 mousePosition3 = Input.mousePosition;
			this.lastMousePos.x = mousePosition3.x;
			this.lastMousePos.y = mousePosition3.y + (float)(mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
			TemMidlet.temCanvas.pointerReleased((int)mousePosition3.x, (int)((float)Screen.height - mousePosition3.y) + mGraphics.addYWhenOpenKeyBoard * mGraphics.zoomLevel);
		}
		if (Input.anyKeyDown && Event.current.type == EventType.KeyDown)
		{
			int num = MyKeyMap.map(Event.current.keyCode);
			if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
			{
				KeyCode keyCode = Event.current.keyCode;
				if (keyCode != KeyCode.Minus)
				{
					if (keyCode == KeyCode.Alpha2)
					{
						num = 64;
					}
				}
				else
				{
					num = 95;
				}
			}
			if (num != 0)
			{
				TemMidlet.temCanvas.keyPressed(num);
			}
		}
		if (Event.current.type == EventType.KeyUp)
		{
			int num2 = MyKeyMap.map(Event.current.keyCode);
			if (num2 != 0)
			{
				TemMidlet.temCanvas.keyReleased(num2);
			}
		}
	}

	// Token: 0x0600002D RID: 45 RVA: 0x00002B44 File Offset: 0x00000D44
	private void OnApplicationQuit()
	{
		Debug.LogWarning("APP QUIT");
		Session_ME.gI().close();
		if (Main.isPC)
		{
			Application.Quit();
		}
	}

	// Token: 0x0600002E RID: 46 RVA: 0x00002B6C File Offset: 0x00000D6C
	private void OnApplicationPause(bool paused)
	{
		Main.isReSume = false;
		if (paused)
		{
			if (GameCanvas.currentDialog != null && GameCanvas.currentDialog.left != null)
			{
				GameCanvas.currentDialog.left.perform();
			}
		}
		else
		{
			Main.isReSume = true;
		}
		if (global::TouchScreenKeyboard.visible)
		{
			TField.kb.active = false;
			TField.kb = null;
		}
		if (Main.isQuitApp)
		{
			Application.Quit();
		}
	}

	// Token: 0x0600002F RID: 47 RVA: 0x00002BE4 File Offset: 0x00000DE4
	public static void exit()
	{
		if (Main.isPC)
		{
			Main.main.OnApplicationQuit();
		}
		else
		{
			Main.a = 0;
		}
	}

	// Token: 0x06000030 RID: 48 RVA: 0x00002C08 File Offset: 0x00000E08
	public static void exit2()
	{
		GameScreen.player.resetAction();
		Session_ME.gI().close();
		GameCanvas.login.Show();
		GameScreen.player = new Player(0, 0, "unname", 0, 0);
	}

	// Token: 0x06000031 RID: 49 RVA: 0x00002C48 File Offset: 0x00000E48
	public static bool detectCompactDevice()
	{
		return iPhoneSettings.generation != iPhoneGeneration.iPhone && iPhoneSettings.generation != iPhoneGeneration.iPhone3G && iPhoneSettings.generation != iPhoneGeneration.iPodTouch1Gen && iPhoneSettings.generation != iPhoneGeneration.iPodTouch2Gen;
	}

	// Token: 0x06000032 RID: 50 RVA: 0x00002C7C File Offset: 0x00000E7C
	public static bool checkCanSendSMS()
	{
		return iPhoneSettings.generation == iPhoneGeneration.iPhone3GS || iPhoneSettings.generation == iPhoneGeneration.iPhone4 || iPhoneSettings.generation > iPhoneGeneration.iPodTouch4Gen;
	}

	// Token: 0x06000033 RID: 51 RVA: 0x00002CA4 File Offset: 0x00000EA4
	public void platformRequest(string url)
	{
		Cout.LogWarning("PLATFORM REQUEST: " + url);
		Application.OpenURL(url);
	}

	// Token: 0x06000034 RID: 52 RVA: 0x00002CBC File Offset: 0x00000EBC
	public static void naptienWP8()
	{
	}

	// Token: 0x06000035 RID: 53 RVA: 0x00002CC0 File Offset: 0x00000EC0
	public void processPurchaseRMS()
	{
	}

	// Token: 0x06000036 RID: 54 RVA: 0x00002CC4 File Offset: 0x00000EC4
	public void ClearTransaction()
	{
	}

	// Token: 0x04000010 RID: 16
	public const sbyte IP_APPSTORE = 3;

	// Token: 0x04000011 RID: 17
	public const sbyte PC_VERSION = 4;

	// Token: 0x04000012 RID: 18
	public const sbyte WINDOWSPHONE = 5;

	// Token: 0x04000013 RID: 19
	public static Main main;

	// Token: 0x04000014 RID: 20
	public static mGraphics g;

	// Token: 0x04000015 RID: 21
	public static TemMidlet tMidlet;

	// Token: 0x04000016 RID: 22
	public static string res = "res";

	// Token: 0x04000017 RID: 23
	public static string mainThreadName;

	// Token: 0x04000018 RID: 24
	public static bool started;

	// Token: 0x04000019 RID: 25
	public static bool isIpod;

	// Token: 0x0400001A RID: 26
	public static bool isIphone4;

	// Token: 0x0400001B RID: 27
	public static bool isIpad;

	// Token: 0x0400001C RID: 28
	public static bool isExit;

	// Token: 0x0400001D RID: 29
	public static bool isPC;

	// Token: 0x0400001E RID: 30
	public static bool isWindowsPhone;

	// Token: 0x0400001F RID: 31
	public static bool isIPhone;

	// Token: 0x04000020 RID: 32
	public static bool isSprite;

	// Token: 0x04000021 RID: 33
	public static bool isWP8;

	// Token: 0x04000022 RID: 34
	public static bool IphoneVersionApp;

	// Token: 0x04000023 RID: 35
	public static string IMEI;

	// Token: 0x04000024 RID: 36
	public static int versionIp;

	// Token: 0x04000025 RID: 37
	public static int numberQuit = 1;

	// Token: 0x04000026 RID: 38
	public static sbyte IPHONE_JB = 2;

	// Token: 0x04000027 RID: 39
	public static int level;

	// Token: 0x04000028 RID: 40
	public static int sizeMiniMap = -1;

	// Token: 0x04000029 RID: 41
	public static bool isLoad;

	// Token: 0x0400002A RID: 42
	private int cout;

	// Token: 0x0400002B RID: 43
	private bool isRun;

	// Token: 0x0400002C RID: 44
	private static Material lineMaterial;

	// Token: 0x0400002D RID: 45
	public static mImage[] imgTileMapLogin;

	// Token: 0x0400002E RID: 46
	public static bool isMiniApp = true;

	// Token: 0x0400002F RID: 47
	public static bool isQuitApp;

	// Token: 0x04000030 RID: 48
	public static bool isReSume;

	// Token: 0x04000031 RID: 49
	private Vector2 lastMousePos = default(Vector2);

	// Token: 0x04000032 RID: 50
	public static int a = 1;

	// Token: 0x04000033 RID: 51
	public static bool isCompactDevice = true;
}
