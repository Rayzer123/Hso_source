using System;
using UnityEngine;

// Token: 0x0200000E RID: 14
public class MyAudioClip
{
	// Token: 0x06000088 RID: 136 RVA: 0x00003A48 File Offset: 0x00001C48
	public MyAudioClip(string filename)
	{
		this.clip = (AudioClip)Resources.Load(filename);
		this.name = filename;
	}

	// Token: 0x06000089 RID: 137 RVA: 0x00003A68 File Offset: 0x00001C68
	public void Play()
	{
		Main.main.GetComponent<AudioSource>().PlayOneShot(this.clip);
		this.timeStart = mSystem.currentTimeMillis();
	}

	// Token: 0x0600008A RID: 138 RVA: 0x00003A98 File Offset: 0x00001C98
	public bool isPlaying()
	{
		return false;
	}

	// Token: 0x0400004B RID: 75
	public string name;

	// Token: 0x0400004C RID: 76
	public AudioClip clip;

	// Token: 0x0400004D RID: 77
	public long timeStart;
}
