using System;

// Token: 0x020000B8 RID: 184
public class FrameImage
{
	// Token: 0x06000941 RID: 2369 RVA: 0x00096D74 File Offset: 0x00094F74
	public FrameImage(mImage img, int width, int height)
	{
		if (img != null)
		{
			this.imgFrame = img;
			this.frameWidth = width;
			this.frameHeight = height;
			this.nFrame = mImage.getImageHeight(img.image) / height;
		}
	}

	// Token: 0x06000942 RID: 2370 RVA: 0x00096DB4 File Offset: 0x00094FB4
	public FrameImage(int ID)
	{
		this.Id = ID;
		mImage mImage = ImageEffect.setImage(ID);
		if (mImage != null)
		{
			this.imgFrame = mImage;
		}
		this.frameWidth = (int)EffectSkill.arrInfoEff[ID][0];
		this.frameHeight = (int)EffectSkill.arrInfoEff[ID][1];
		this.nFrame = (int)EffectSkill.arrInfoEff[ID][2];
	}

	// Token: 0x06000943 RID: 2371 RVA: 0x00096E1C File Offset: 0x0009501C
	public FrameImage(mImage img, int numW, int numH, int numNull)
	{
		this.numWidth = numW;
		this.numHeight = numH;
		this.frameWidth = mImage.getImageWidth(img.image) / numW;
		this.frameHeight = mImage.getImageHeight(img.image) / numH;
		this.nFrame = numW * numH - numNull;
	}

	// Token: 0x06000944 RID: 2372 RVA: 0x00096E78 File Offset: 0x00095078
	public FrameImage(int ID, int numW, int numH, int numNull, int n)
	{
		this.Id = ID;
		this.isNgua = true;
		this.numWidth = numW;
		this.numHeight = numH;
		mImage im = mImage.createImage("/vantieu/bo.png");
		MainImage mainImage = new MainImage(im);
		if (mainImage != null && mainImage.img != null)
		{
			this.imgFrame = mainImage.img;
			this.frameWidth = mImage.getImageWidth(this.imgFrame.image) / numW;
			this.frameHeight = mImage.getImageHeight(this.imgFrame.image) / numH;
			if (this.imgFrame != null || this.imgFrame.image != null)
			{
				this.nFrame = numW * numH - numNull;
			}
		}
	}

	// Token: 0x06000945 RID: 2373 RVA: 0x00096F34 File Offset: 0x00095134
	public FrameImage(int ID, int numW, int numH, int numNull)
	{
		this.Id = ID;
		this.isNgua = true;
		this.numWidth = numW;
		this.numHeight = numH;
		MainImage imageMount = ObjectData.getImageMount((short)ID);
		if (imageMount != null && imageMount.img != null)
		{
			this.imgFrame = imageMount.img;
			this.frameWidth = mImage.getImageWidth(this.imgFrame.image) / numW;
			this.frameHeight = mImage.getImageHeight(this.imgFrame.image) / numH;
			if (this.imgFrame != null || this.imgFrame.image != null)
			{
				this.nFrame = numW * numH - numNull;
			}
		}
	}

	// Token: 0x06000947 RID: 2375 RVA: 0x00096FF4 File Offset: 0x000951F4
	public int getNFrame()
	{
		return this.nFrame;
	}

	// Token: 0x06000948 RID: 2376 RVA: 0x00096FFC File Offset: 0x000951FC
	public static FrameImage init(string path, int w, int h)
	{
		return new FrameImage(FilePack.getImg(path), w, h);
	}

	// Token: 0x06000949 RID: 2377 RVA: 0x0009700C File Offset: 0x0009520C
	public static FrameImage getFrameImageMount(short id, int numW, int numH, int numNull)
	{
		FrameImage frameImage = (FrameImage)FrameImage.HashFrameImageMount.get(string.Empty + id);
		if (frameImage == null)
		{
			frameImage = new FrameImage((int)id, numW, numH, numNull);
			FrameImage.HashFrameImageMount.put(string.Empty + id, frameImage);
		}
		else if (frameImage.imgFrame == null)
		{
			MainImage imageMount = ObjectData.getImageMount(id);
			if (imageMount != null && imageMount.img != null)
			{
				frameImage.imgFrame = imageMount.img;
				frameImage.numWidth = numW;
				frameImage.numHeight = numH;
				frameImage.frameWidth = mImage.getImageWidth(frameImage.imgFrame.image) / numW;
				frameImage.frameHeight = mImage.getImageHeight(frameImage.imgFrame.image) / numH;
				if (frameImage.imgFrame != null || frameImage.imgFrame.image != null)
				{
					frameImage.nFrame = numW * numH - numNull;
				}
			}
		}
		else
		{
			frameImage.numWidth = numW;
			frameImage.numHeight = numH;
			frameImage.frameWidth = mImage.getImageWidth(frameImage.imgFrame.image) / numW;
			frameImage.frameHeight = mImage.getImageHeight(frameImage.imgFrame.image) / numH;
			if (frameImage.imgFrame != null || frameImage.imgFrame.image != null)
			{
				frameImage.nFrame = numW * numH - numNull;
			}
		}
		return frameImage;
	}

	// Token: 0x0600094A RID: 2378 RVA: 0x00097168 File Offset: 0x00095368
	public void drawFrameNew(int idx, int x, int y, int trans, int orthor, mGraphics g)
	{
		if (idx >= 0 && idx < this.nFrame)
		{
			try
			{
				int y2 = idx * this.frameHeight;
				int x2 = idx / this.numHeight * this.frameWidth;
				y2 = idx % this.numHeight * this.frameHeight;
				g.drawRegion(this.imgFrame, x2, y2, this.frameWidth, this.frameHeight, trans, x, y, orthor, mGraphics.isTrue);
			}
			catch (Exception ex)
			{
			}
		}
	}

	// Token: 0x0600094B RID: 2379 RVA: 0x00097200 File Offset: 0x00095400
	public void drawFrame(int idx, int x, int y, int trans, int orthor, mGraphics g)
	{
		if (this.imgFrame == null || this.imgFrame.image == null)
		{
			mImage mImage = ImageEffect.setImage(this.Id);
			if (mImage != null)
			{
				this.imgFrame = mImage;
			}
			if (mImage.image != null)
			{
				this.nFrame = mImage.getImageHeight(this.imgFrame.image) / this.frameHeight;
			}
		}
		else if (idx >= 0 && idx < this.nFrame)
		{
			g.drawRegion(this.imgFrame, 0, idx * this.frameHeight, this.frameWidth, this.frameHeight, trans, x, y, orthor, mGraphics.isTrue);
		}
	}

	// Token: 0x0600094C RID: 2380 RVA: 0x000972B0 File Offset: 0x000954B0
	public void drawFrameEffectSkill(int idx, int x, int y, int trans, int orthor, mGraphics g)
	{
		mImage mImage = ImageEffect.setImage(this.Id);
		if (mImage != null && mImage.image != null)
		{
			if (idx > this.nFrame)
			{
				idx = this.nFrame;
			}
			int num = idx * this.frameHeight;
			if (num > this.frameHeight * (this.nFrame - 1) || num < 0)
			{
				num = this.frameHeight * (this.nFrame - 1);
			}
			g.drawRegion(mImage, 0, num, this.frameWidth, this.frameHeight, trans, x, y, orthor, mGraphics.isTrue);
		}
	}

	// Token: 0x0600094D RID: 2381 RVA: 0x00097344 File Offset: 0x00095544
	public void drawFrameEffectSkill1(int idx, int x, int y, int trans, mGraphics g)
	{
		mImage mImage = ImageEffect.setImage(this.Id);
		if (mImage != null && mImage.image != null)
		{
			if (idx > this.nFrame)
			{
				idx = this.nFrame;
			}
			int num = idx * this.frameHeight;
			if (num > this.frameHeight * (this.nFrame - 1) || num < 0)
			{
				num = this.frameHeight * (this.nFrame - 1);
			}
			g.drawRegion(mImage, 0, num, this.frameWidth, this.frameHeight, trans, x, y, 0, mGraphics.isTrue);
		}
	}

	// Token: 0x0600094E RID: 2382 RVA: 0x000973D8 File Offset: 0x000955D8
	public void drawFrame(int idx, int x, int y, int trans, mGraphics g)
	{
		if (this.imgFrame == null || this.imgFrame.image == null)
		{
			mImage mImage = ImageEffect.setImage(this.Id);
			if (mImage != null)
			{
				this.imgFrame = mImage;
			}
			if (this.imgFrame.image != null)
			{
				this.nFrame = mImage.getImageHeight(this.imgFrame.image) / this.frameHeight;
			}
		}
		else if (idx >= 0 && idx < this.nFrame)
		{
			g.drawRegion(this.imgFrame, 0, idx * this.frameHeight, this.frameWidth, this.frameHeight, trans, x, y, 0, mGraphics.isTrue);
		}
	}

	// Token: 0x0600094F RID: 2383 RVA: 0x0009748C File Offset: 0x0009568C
	public void drawFrameXY(int idx, int idy, int x, int y, mGraphics g)
	{
		if (this.imgFrame == null)
		{
			mImage mImage = ImageEffect.setImage(this.Id);
			if (mImage != null)
			{
				this.imgFrame = mImage;
			}
			if (this.imgFrame.image != null)
			{
				this.nFrame = mImage.getImageHeight(this.imgFrame.image) / this.frameHeight;
			}
		}
		else if (idx >= 0 && idx < this.nFrame)
		{
			g.drawRegion(this.imgFrame, idx * this.frameWidth, idy * this.frameHeight, this.frameWidth, this.frameHeight, 0, x, y, 0, mGraphics.isTrue);
		}
	}

	// Token: 0x04000E23 RID: 3619
	public int frameWidth;

	// Token: 0x04000E24 RID: 3620
	public int frameHeight;

	// Token: 0x04000E25 RID: 3621
	public int nFrame;

	// Token: 0x04000E26 RID: 3622
	public mImage imgFrame;

	// Token: 0x04000E27 RID: 3623
	public int Id = -1;

	// Token: 0x04000E28 RID: 3624
	public int numWidth;

	// Token: 0x04000E29 RID: 3625
	public int numHeight;

	// Token: 0x04000E2A RID: 3626
	public static mHashTable HashFrameImageMount = new mHashTable();

	// Token: 0x04000E2B RID: 3627
	private bool isNgua;
}
