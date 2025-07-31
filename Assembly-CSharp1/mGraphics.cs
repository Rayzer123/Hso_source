using System;
using System.Collections;
using UnityEngine;

// Token: 0x02000027 RID: 39
public class mGraphics
{
	// Token: 0x060001A0 RID: 416 RVA: 0x0000A058 File Offset: 0x00008258
	private void cache(string key, Texture value)
	{
		if (mGraphics.cachedTextures.Count > 400)
		{
			mGraphics.cachedTextures.Clear();
		}
		if (value.width * value.height < GameCanvas.w * GameCanvas.h)
		{
			mGraphics.cachedTextures.Add(key, value);
		}
	}

	// Token: 0x060001A1 RID: 417 RVA: 0x0000A0AC File Offset: 0x000082AC
	public void drawRegionNotSetClip(mImage arg0, int x0, int y0, int w0, int h0, int arg5, int x, int y, int anchor)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		x0 *= mGraphics.zoomLevel;
		y0 *= mGraphics.zoomLevel;
		w0 *= mGraphics.zoomLevel;
		h0 *= mGraphics.zoomLevel;
		this._drawRegion(arg0.image, (float)x0, (float)y0, w0, h0, arg5, x, y, anchor, false);
	}

	// Token: 0x060001A2 RID: 418 RVA: 0x0000A110 File Offset: 0x00008310
	public void translate(int tx, int ty)
	{
		tx *= mGraphics.zoomLevel;
		ty *= mGraphics.zoomLevel;
		this.translateX += tx;
		this.translateY += ty;
		this.isTranslate = true;
		if (this.translateX == 0 && this.translateY == 0)
		{
			this.isTranslate = false;
		}
	}

	// Token: 0x060001A3 RID: 419 RVA: 0x0000A170 File Offset: 0x00008370
	public int getTranslateX()
	{
		return this.translateX / mGraphics.zoomLevel;
	}

	// Token: 0x060001A4 RID: 420 RVA: 0x0000A180 File Offset: 0x00008380
	public int getTranslateY()
	{
		return this.translateY / mGraphics.zoomLevel + mGraphics.addYWhenOpenKeyBoard;
	}

	// Token: 0x060001A5 RID: 421 RVA: 0x0000A194 File Offset: 0x00008394
	public void setClip(int x, int y, int w, int h)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		w *= mGraphics.zoomLevel;
		h *= mGraphics.zoomLevel;
		this.clipTX = this.translateX;
		this.clipTY = this.translateY;
		this.clipX = x;
		this.clipY = y;
		this.clipW = w;
		this.clipH = h;
		this.isClip = true;
	}

	// Token: 0x060001A6 RID: 422 RVA: 0x0000A204 File Offset: 0x00008404
	public void fillRecAlpla(int x, int y, int w, int h, int color)
	{
		this.drawRecAlpa(0, 0, GameCanvas.loadmap.mapW * 24, y, color);
		this.drawRecAlpa(0, y, x, GameCanvas.loadmap.mapH * 24 - y, color);
		this.drawRecAlpa(x, y + h, GameCanvas.loadmap.mapW * 24 - x, GameCanvas.loadmap.mapH * 24 - (y + h), color);
		this.drawRecAlpa(x + w, y, GameCanvas.loadmap.mapW * 24 - (x + w), h, color);
	}

	// Token: 0x060001A7 RID: 423 RVA: 0x0000A290 File Offset: 0x00008490
	public void drawRecAlpa(int x, int y, int w, int h, int color)
	{
		float alpha = 0.5f;
		this.setColor(color, alpha);
		this.fillRect(x, y, w, h, false);
	}

	// Token: 0x060001A8 RID: 424 RVA: 0x0000A2B8 File Offset: 0x000084B8
	public void fillRect(int x, int y, int w, int h, int color, int alpha, bool useClip)
	{
		float alpha2 = 0.5f;
		this.setColor(color, alpha2);
		this.fillRect(x, y, w, h, useClip);
	}

	// Token: 0x060001A9 RID: 425 RVA: 0x0000A2E4 File Offset: 0x000084E4
	public void drawLine(int x1, int y1, int x2, int y2, bool useClip)
	{
		for (int i = 0; i < mGraphics.zoomLevel; i++)
		{
			this._drawLine(x1 + i, y1 + i, x2 + i, y2 + i, useClip);
			if (i > 0)
			{
				this._drawLine(x1 + i, y1, x2 + i, y2, useClip);
				this._drawLine(x1, y1 + i, x2, y2 + i, useClip);
			}
		}
	}

	// Token: 0x060001AA RID: 426 RVA: 0x0000A348 File Offset: 0x00008548
	public void drawlineGL()
	{
		this.lineMaterial.SetPass(0);
		GL.PushMatrix();
		GL.Begin(1);
		for (int i = 0; i < this.totalLine.size(); i++)
		{
			mLine mLine = (mLine)this.totalLine.elementAt(i);
			GL.Color(new Color(mLine.r, mLine.g, mLine.b, mLine.a));
			int num = mLine.x1 * mGraphics.zoomLevel;
			int num2 = mLine.y1 * mGraphics.zoomLevel;
			int num3 = mLine.x2 * mGraphics.zoomLevel;
			int num4 = mLine.y2 * mGraphics.zoomLevel;
			if (this.isTranslate)
			{
				num += this.translateX;
				num2 += this.translateY;
				num3 += this.translateX;
				num4 += this.translateY;
			}
			for (int j = 0; j < mGraphics.zoomLevel; j++)
			{
				GL.Vertex(new Vector2((float)(num + j), (float)(num2 + j)));
				GL.Vertex(new Vector2((float)(num3 + j), (float)(num4 + j)));
				if (j > 0)
				{
					GL.Vertex(new Vector2((float)(num + j), (float)num2));
					GL.Vertex(new Vector2((float)(num3 + j), (float)num4));
					GL.Vertex(new Vector2((float)num, (float)(num2 + j)));
					GL.Vertex(new Vector2((float)num3, (float)(num4 + j)));
				}
			}
		}
		GL.End();
		GL.PopMatrix();
		this.totalLine.removeAllElements();
	}

	// Token: 0x060001AB RID: 427 RVA: 0x0000A4F0 File Offset: 0x000086F0
	public void test()
	{
		GL.PushMatrix();
		this.lineMaterial.SetPass(0);
		GL.LoadPixelMatrix();
		GL.Vertex(new Vector2(10f, 10f));
		GL.Vertex(new Vector2(100f, 100f));
		GL.End();
		GL.PopMatrix();
	}

	// Token: 0x060001AC RID: 428 RVA: 0x0000A550 File Offset: 0x00008750
	public void CreateLineMaterial()
	{
		if (!this.lineMaterial)
		{
			this.lineMaterial = new Material("Shader \"Lines/Colored Blended\" {SubShader { Pass {  Blend SrcAlpha OneMinusSrcAlpha  ZWrite Off Cull Off Fog { Mode Off }  BindChannels { Bind \"vertex\", vertex Bind \"color\", color }} } }");
			this.lineMaterial.hideFlags = HideFlags.HideAndDontSave;
			this.lineMaterial.shader.hideFlags = HideFlags.HideAndDontSave;
		}
	}

	// Token: 0x060001AD RID: 429 RVA: 0x0000A59C File Offset: 0x0000879C
	public void drawLine2(int x1, int y1, int x2, int y2, float r, float b, float g, float a)
	{
		this._drawLine2(x1, y1, x2, y2, r, b, g, a);
	}

	// Token: 0x060001AE RID: 430 RVA: 0x0000A5BC File Offset: 0x000087BC
	public void _drawLine2(int x1, int y1, int x2, int y2, float r, float b, float g, float a)
	{
		x1 *= mGraphics.zoomLevel;
		y1 *= mGraphics.zoomLevel;
		x2 *= mGraphics.zoomLevel;
		y2 *= mGraphics.zoomLevel;
		if (this.isTranslate)
		{
			x1 += this.translateX;
			y1 += this.translateY;
			x2 += this.translateX;
			y2 += this.translateY;
		}
		this.lineMaterial.SetPass(0);
		GL.PushMatrix();
		GL.Begin(1);
		GL.Color(new Color(r, g, b, a));
		GL.Vertex(new Vector2((float)x1, (float)y1));
		GL.Vertex(new Vector2((float)x2, (float)y2));
		GL.End();
		GL.PopMatrix();
	}

	// Token: 0x060001AF RID: 431 RVA: 0x0000A680 File Offset: 0x00008880
	public void _drawLine(int x1, int y1, int x2, int y2, bool useClip)
	{
		x1 *= mGraphics.zoomLevel;
		y1 *= mGraphics.zoomLevel;
		x2 *= mGraphics.zoomLevel;
		y2 *= mGraphics.zoomLevel;
		if (y1 == y2)
		{
			if (x1 > x2)
			{
				int num = x2;
				x2 = x1;
				x1 = num;
			}
			this.fillRect(x1, y1, x2 - x1, 1, useClip);
			return;
		}
		if (x1 == x2)
		{
			if (y1 > y2)
			{
				int num2 = y2;
				y2 = y1;
				y1 = num2;
			}
			this.fillRect(x1, y1, 1, y2 - y1, useClip);
			return;
		}
		if (this.isTranslate)
		{
			x1 += this.translateX;
			y1 += this.translateY;
			x2 += this.translateX;
			y2 += this.translateY;
		}
		string key = string.Concat(new object[]
		{
			"dl",
			this.r,
			this.g,
			this.b
		});
		Texture2D texture2D = (Texture2D)mGraphics.cachedTextures[key];
		if (texture2D == null)
		{
			texture2D = new Texture2D(1, 1);
			Color color = new Color(this.r, this.g, this.b);
			texture2D.SetPixel(0, 0, color);
			texture2D.Apply();
			this.cache(key, texture2D);
		}
		Vector2 pivotPoint = new Vector2((float)x1, (float)y1);
		Vector2 vector = new Vector2((float)x2, (float)y2);
		Vector2 vector2 = vector - pivotPoint;
		float num3 = 57.29578f * Mathf.Atan(vector2.y / vector2.x);
		if (vector2.x < 0f)
		{
			num3 += 180f;
		}
		int num4 = (int)Mathf.Ceil(0f);
		GUIUtility.RotateAroundPivot(num3, pivotPoint);
		int num5 = 0;
		int num6 = 0;
		int num7 = 0;
		int num8 = 0;
		if (this.isClip && useClip)
		{
			num5 = this.clipX;
			num6 = this.clipY;
			num7 = this.clipW;
			num8 = this.clipH;
			if (this.isTranslate)
			{
				num5 += this.clipTX;
				num6 += this.clipTY;
			}
		}
		if (this.isClip && useClip)
		{
			GUI.BeginGroup(new Rect((float)num5, (float)num6, (float)num7, (float)num8));
		}
		Graphics.DrawTexture(new Rect(pivotPoint.x - (float)num5, pivotPoint.y - (float)num4 - (float)num6, vector2.magnitude, 1f), texture2D);
		if (this.isClip && useClip)
		{
			GUI.EndGroup();
		}
		GUIUtility.RotateAroundPivot(-num3, pivotPoint);
	}

	// Token: 0x060001B0 RID: 432 RVA: 0x0000A910 File Offset: 0x00008B10
	public Color setColorMiniMap(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		float num4 = (float)num / 256f;
		float num5 = (float)num2 / 256f;
		float num6 = (float)num3 / 256f;
		Color result = new Color(num6, num5, num4);
		return result;
	}

	// Token: 0x060001B1 RID: 433 RVA: 0x0000A968 File Offset: 0x00008B68
	public float[] getRGB(Color cl)
	{
		float num = 256f * cl.r;
		float num2 = 256f * cl.g;
		float num3 = 256f * cl.b;
		return new float[]
		{
			num,
			num2,
			num3
		};
	}

	// Token: 0x060001B2 RID: 434 RVA: 0x0000A9B4 File Offset: 0x00008BB4
	public void drawRect(int x, int y, int w, int h, bool useClip)
	{
		int num = 1;
		this.fillRect(x, y, w, num, useClip);
		this.fillRect(x, y, num, h, useClip);
		this.fillRect(x + w, y, num, h + 1, useClip);
		this.fillRect(x, y + h, w + 1, num, useClip);
	}

	// Token: 0x060001B3 RID: 435 RVA: 0x0000AA00 File Offset: 0x00008C00
	public void fillRect(int x, int y, int w, int h, bool useClip)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		w *= mGraphics.zoomLevel;
		h *= mGraphics.zoomLevel;
		if (w < 0 || h < 0)
		{
			return;
		}
		if (this.isTranslate)
		{
			x += this.translateX;
			y += this.translateY;
		}
		int num = 1;
		int num2 = 1;
		string key = string.Concat(new object[]
		{
			"fr",
			num,
			num2,
			this.r,
			this.g,
			this.b,
			this.a
		});
		Texture2D texture2D = (Texture2D)mGraphics.cachedTextures[key];
		if (texture2D == null)
		{
			texture2D = new Texture2D(num, num2);
			Color color = new Color(this.r, this.g, this.b, this.a);
			texture2D.SetPixel(0, 0, color);
			texture2D.Apply();
			this.cache(key, texture2D);
		}
		int num3 = 0;
		int num4 = 0;
		int num5 = 0;
		int num6 = 0;
		if (this.isClip && useClip)
		{
			num3 = this.clipX;
			num4 = this.clipY;
			num5 = this.clipW;
			num6 = this.clipH;
			if (this.isTranslate)
			{
				num3 += this.clipTX;
				num4 += this.clipTY;
			}
		}
		if (this.isClip && useClip)
		{
			GUI.BeginGroup(new Rect((float)num3, (float)num4, (float)num5, (float)num6));
		}
		GUI.DrawTexture(new Rect((float)(x - num3), (float)(y - num4), (float)w, (float)h), texture2D);
		if (this.isClip && useClip)
		{
			GUI.EndGroup();
		}
	}

	// Token: 0x060001B4 RID: 436 RVA: 0x0000ABD8 File Offset: 0x00008DD8
	public void setColor(int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		this.b = (float)num / 256f;
		this.g = (float)num2 / 256f;
		this.r = (float)num3 / 256f;
		this.a = 255f;
	}

	// Token: 0x060001B5 RID: 437 RVA: 0x0000AC38 File Offset: 0x00008E38
	public void setColor(Color color)
	{
		this.b = color.b;
		this.g = color.g;
		this.r = color.r;
	}

	// Token: 0x060001B6 RID: 438 RVA: 0x0000AC64 File Offset: 0x00008E64
	public void setBgColor(int rgb)
	{
		if (rgb != this.currentBGColor)
		{
			this.currentBGColor = rgb;
			int num = rgb & 255;
			int num2 = rgb >> 8 & 255;
			int num3 = rgb >> 16 & 255;
			this.b = (float)num / 256f;
			this.g = (float)num2 / 256f;
			this.r = (float)num3 / 256f;
			Main.main.GetComponent<UnityEngine.Camera>().backgroundColor = new Color(this.r, this.g, this.b);
		}
	}

	// Token: 0x060001B7 RID: 439 RVA: 0x0000ACF4 File Offset: 0x00008EF4
	public void drawString(string s, int x, int y, GUIStyle style, bool useClip)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		if (this.isTranslate)
		{
			x += this.translateX;
			y += this.translateY;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		if (this.isClip && useClip)
		{
			num = this.clipX;
			num2 = this.clipY;
			num3 = this.clipW;
			num4 = this.clipH;
			if (this.isTranslate)
			{
				num += this.clipTX;
				num2 += this.clipTY;
			}
		}
		if (this.isClip && useClip)
		{
			GUI.BeginGroup(new Rect((float)num, (float)num2, (float)num3, (float)num4));
		}
		GUI.Label(new Rect((float)(x - num), (float)(y - num2), ScaleGUI.WIDTH, 100f), s, style);
		if (this.isClip && useClip)
		{
			GUI.EndGroup();
		}
	}

	// Token: 0x060001B8 RID: 440 RVA: 0x0000ADE0 File Offset: 0x00008FE0
	public void setColor(int rgb, float alpha)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		this.b = (float)num / 256f;
		this.g = (float)num2 / 256f;
		this.r = (float)num3 / 256f;
		this.a = alpha;
	}

	// Token: 0x060001B9 RID: 441 RVA: 0x0000AE3C File Offset: 0x0000903C
	public void drawString(string s, int x, int y, GUIStyle style, int wString, bool useClip)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		wString *= mGraphics.zoomLevel;
		if (this.isTranslate)
		{
			x += this.translateX;
			y += this.translateY;
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		if (this.isClip && useClip)
		{
			num = this.clipX;
			num2 = this.clipY;
			num3 = this.clipW;
			num4 = this.clipH;
			if (this.isTranslate)
			{
				num += this.clipTX;
				num2 += this.clipTY;
			}
		}
		if (this.isClip && useClip)
		{
			GUI.BeginGroup(new Rect((float)num, (float)num2, (float)num3, (float)num4));
		}
		int num5 = 0;
		if ((float)wString > ScaleGUI.WIDTH)
		{
			num5 = wString;
		}
		GUI.Label(new Rect((float)(x - num), (float)(y - num2 - 4), ScaleGUI.WIDTH + (float)num5, 100f), s, style);
		if (this.isClip && useClip)
		{
			GUI.EndGroup();
		}
	}

	// Token: 0x060001BA RID: 442 RVA: 0x0000AF4C File Offset: 0x0000914C
	private void UpdatePos(int anchor)
	{
		Vector2 vector = new Vector2(0f, 0f);
		switch (anchor)
		{
		case 3:
			vector = new Vector2(this.size.x / 2f, this.size.y / 2f);
			break;
		default:
			switch (anchor)
			{
			case 17:
				vector = new Vector2((float)(Screen.width / 2), 0f);
				break;
			default:
				switch (anchor)
				{
				case 33:
					vector = new Vector2((float)(Screen.width / 2), (float)Screen.height);
					break;
				default:
					if (anchor != 10)
					{
						if (anchor != 24)
						{
							if (anchor == 40)
							{
								vector = new Vector2((float)Screen.width, (float)Screen.height);
							}
						}
						else
						{
							vector = new Vector2((float)Screen.width, 0f);
						}
					}
					else
					{
						vector = new Vector2((float)Screen.width, (float)(Screen.height / 2));
					}
					break;
				case 36:
					vector = new Vector2(0f, (float)Screen.height);
					break;
				}
				break;
			case 20:
				vector = new Vector2(0f, 0f);
				break;
			}
			break;
		case 6:
			vector = new Vector2(0f, (float)(Screen.height / 2));
			break;
		}
		this.pos = vector + this.relativePosition;
		this.rect = new Rect(this.pos.x - this.size.x * 0.5f, this.pos.y - this.size.y * 0.5f, this.size.x, this.size.y);
		this.pivot = new Vector2(this.rect.xMin + this.rect.width * 0.5f, this.rect.yMin + this.rect.height * 0.5f);
	}

	// Token: 0x060001BB RID: 443 RVA: 0x0000B17C File Offset: 0x0000937C
	public void drawRegion(mImage arg0, int x0, int y0, int w0, int h0, int arg5, int x, int y, int arg8, bool useClip)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		x0 *= mGraphics.zoomLevel;
		y0 *= mGraphics.zoomLevel;
		w0 *= mGraphics.zoomLevel;
		h0 *= mGraphics.zoomLevel;
		this._drawRegion(arg0.image, (float)x0, (float)y0, w0, h0, arg5, x, y, arg8, useClip);
	}

	// Token: 0x060001BC RID: 444 RVA: 0x0000B1E4 File Offset: 0x000093E4
	public void _drawRegion(Image image, float x0, float y0, int w, int h, int transform, int x, int y, int anchor, bool useClip)
	{
		if (image == null)
		{
			return;
		}
		if (this.isTranslate)
		{
			x += this.translateX;
			y += this.translateY;
		}
		float num = (float)w;
		float num2 = (float)h;
		float num3 = 0f;
		float num4 = 0f;
		float num5 = 0f;
		float num6 = 0f;
		float num7 = 1f;
		float num8 = 0f;
		int num9 = 1;
		if ((anchor & mGraphics.HCENTER) == mGraphics.HCENTER)
		{
			num5 -= num / 2f;
		}
		if ((anchor & mGraphics.VCENTER) == mGraphics.VCENTER)
		{
			num6 -= num2 / 2f;
		}
		if ((anchor & mGraphics.RIGHT) == mGraphics.RIGHT)
		{
			num5 -= num;
		}
		if ((anchor & mGraphics.BOTTOM) == mGraphics.BOTTOM)
		{
			num6 -= num2;
		}
		x += (int)num5;
		y += (int)num6;
		int num10 = 0;
		int num11 = 0;
		if (this.isClip && useClip)
		{
			num10 = this.clipX;
			int num12 = this.clipY;
			num11 = this.clipW;
			int num13 = this.clipH;
			if (this.isTranslate)
			{
				num10 += this.clipTX;
				num12 += this.clipTY;
			}
			Rect r = new Rect((float)x, (float)y, (float)w, (float)h);
			Rect r2 = new Rect((float)num10, (float)num12, (float)num11, (float)num13);
			Rect rect = this.intersectRect(r, r2);
			if (rect.width <= 0f || rect.height <= 0f)
			{
				return;
			}
			num = rect.width;
			num2 = rect.height;
			num3 = rect.x - r.x;
			num4 = rect.y - r.y;
		}
		float num14 = 0f;
		float num15 = 0f;
		if (transform == 2)
		{
			num14 += num;
			num7 = -1f;
			if (this.isClip && useClip)
			{
				if (num10 > x)
				{
					num8 = -num3;
				}
				else if (num10 + num11 < x + w)
				{
					num8 = (float)(-(float)(num10 + num11 - x - w));
				}
			}
		}
		else if (transform == 1)
		{
			num9 = -1;
			num15 += num2;
		}
		else if (transform == 3)
		{
			num9 = -1;
			num15 += num2;
			num7 = -1f;
			num14 += num;
		}
		int num16 = 0;
		int num17 = 0;
		if (transform == 5 || transform == 6 || transform == 4 || transform == 7)
		{
			this.matrixBackup = GUI.matrix;
			this.size = new Vector2((float)w, (float)h);
			this.relativePosition = new Vector2((float)x, (float)y);
			this.UpdatePos(3);
			if (transform == 6)
			{
				this.size = new Vector2((float)w, (float)(h - 1));
				this.UpdatePos(3);
				GUIUtility.RotateAroundPivot(0f, this.pivot);
			}
			else if (transform == 5)
			{
				this.size = new Vector2((float)w, (float)(h - 1));
				this.UpdatePos(3);
				GUIUtility.RotateAroundPivot(90f, this.pivot);
			}
			if (transform == 6)
			{
				GUIUtility.RotateAroundPivot(270f, this.pivot);
			}
			else if (transform == 4)
			{
				this.size = new Vector2((float)w, (float)(h - 1));
				this.UpdatePos(3);
				GUIUtility.RotateAroundPivot(90f, this.pivot);
				num9 = -1;
				num15 += num2;
			}
			else if (transform == 7)
			{
				this.size = new Vector2((float)w, (float)(h - 1));
				this.UpdatePos(3);
				GUIUtility.RotateAroundPivot(270f, this.pivot);
				num9 = -1;
				num15 += num2;
			}
		}
		Graphics.DrawTexture(new Rect((float)x + num3 + num14 + (float)num16, (float)y + num4 + (float)num17 + num15, num * num7, num2 * (float)num9), image.texture, new Rect((x0 + num3 + num8) / (float)image.texture.width, ((float)image.texture.height - num2 - (y0 + num4)) / (float)image.texture.height, num / (float)image.texture.width, num2 / (float)image.texture.height), 0, 0, 0, 0);
		if (transform == 5 || transform == 6 || transform == 4 || transform == 7)
		{
			GUI.matrix = this.matrixBackup;
		}
	}

	// Token: 0x060001BD RID: 445 RVA: 0x0000B65C File Offset: 0x0000985C
	public void setClip2(int x, int y, int w, int h)
	{
		GUI.BeginGroup(new Rect((float)x, (float)y, (float)w, (float)h));
	}

	// Token: 0x060001BE RID: 446 RVA: 0x0000B674 File Offset: 0x00009874
	public void enClip()
	{
		GUI.EndGroup();
	}

	// Token: 0x060001BF RID: 447 RVA: 0x0000B67C File Offset: 0x0000987C
	public void drawRegionGui2(Image image, float x0, float y0, float w, float h, int transform, float x, float y, int anchor)
	{
		Rect position = new Rect(x, y, w, h);
		Rect texCoords = new Rect(0f, 0f, w / (float)image.texture.width, 1f);
		GUI.DrawTextureWithTexCoords(position, image.texture, texCoords);
		Debug.Log(w / (float)image.texture.width + ".");
	}

	// Token: 0x060001C0 RID: 448 RVA: 0x0000B6F0 File Offset: 0x000098F0
	public void drawRegionT(Texture2D imageTexture, float x0, float y0, int w, int h, int transform, float x, float y, float wScale, float hScale, int anchor)
	{
		if (transform == 0)
		{
			GUI.DrawTextureWithTexCoords(new Rect(x0, y0, (float)w, (float)h), imageTexture, new Rect(x / (float)imageTexture.width, y / (float)imageTexture.height, wScale / (float)imageTexture.width, hScale / (float)imageTexture.height));
		}
		if (transform == 2)
		{
			GUI.DrawTextureWithTexCoords(new Rect(x0, y0, (float)w, (float)h), imageTexture, new Rect((x + wScale) / (float)imageTexture.width, y / (float)imageTexture.height, -wScale / (float)imageTexture.width, hScale / (float)imageTexture.height));
		}
	}

	// Token: 0x060001C1 RID: 449 RVA: 0x0000B790 File Offset: 0x00009990
	public void drawRegionGui(Image image, float x0, float y0, int w, int h, int transform, float x, float y, int anchor)
	{
		GUI.color = this.setColorMiniMap(807956);
		x *= (float)mGraphics.zoomLevel;
		y *= (float)mGraphics.zoomLevel;
		x0 *= (float)mGraphics.zoomLevel;
		y0 *= (float)mGraphics.zoomLevel;
		w *= mGraphics.zoomLevel;
		h *= mGraphics.zoomLevel;
	}

	// Token: 0x060001C2 RID: 450 RVA: 0x0000B7EC File Offset: 0x000099EC
	public void drawRegion2(Image image, float x0, float y0, int w, int h, int transform, int x, int y, int anchor, bool useClip)
	{
		GUI.color = image.colorBlend;
		if (this.isTranslate)
		{
			x += this.translateX;
			y += this.translateY;
		}
		string key = string.Concat(new object[]
		{
			"dg",
			x0,
			y0,
			w,
			h,
			transform,
			image.GetHashCode()
		});
		Texture2D texture2D = (Texture2D)mGraphics.cachedTextures[key];
		if (texture2D == null)
		{
			Image image2 = Image.createImage(image, (int)x0, (int)y0, w, h, transform);
			texture2D = image2.texture;
			this.cache(key, texture2D);
		}
		int num = 0;
		int num2 = 0;
		int num3 = 0;
		int num4 = 0;
		float num5 = (float)w;
		float num6 = (float)h;
		float num7 = 0f;
		float num8 = 0f;
		if ((anchor & mGraphics.HCENTER) == mGraphics.HCENTER)
		{
			num7 -= num5 / 2f;
		}
		if ((anchor & mGraphics.VCENTER) == mGraphics.VCENTER)
		{
			num8 -= num6 / 2f;
		}
		if ((anchor & mGraphics.RIGHT) == mGraphics.RIGHT)
		{
			num7 -= num5;
		}
		if ((anchor & mGraphics.BOTTOM) == mGraphics.BOTTOM)
		{
			num8 -= num6;
		}
		x += (int)num7;
		y += (int)num8;
		if (this.isClip && useClip)
		{
			num = this.clipX;
			num2 = this.clipY;
			num3 = this.clipW;
			num4 = this.clipH;
			if (this.isTranslate)
			{
				num += this.clipTX;
				num2 += this.clipTY;
			}
		}
		if (this.isClip && useClip)
		{
			GUI.BeginGroup(new Rect((float)num, (float)num2, (float)num3, (float)num4));
		}
		GUI.DrawTexture(new Rect((float)(x - num), (float)(y - num2), (float)w, (float)h), texture2D);
		if (this.isClip && useClip)
		{
			GUI.EndGroup();
		}
		GUI.color = new Color(1f, 1f, 1f, 1f);
	}

	// Token: 0x060001C3 RID: 451 RVA: 0x0000BA20 File Offset: 0x00009C20
	public void drawImagaByDrawTexture(mImage image, float x, float y)
	{
		x *= (float)mGraphics.zoomLevel;
		y *= (float)mGraphics.zoomLevel;
		GUI.DrawTexture(new Rect(x + (float)this.translateX, y + (float)this.translateY, (float)image.image.getRealImageWidth(), (float)image.image.getRealImageHeight()), image.image.texture);
	}

	// Token: 0x060001C4 RID: 452 RVA: 0x0000BA80 File Offset: 0x00009C80
	public void drawImage(mImage image, int x, int y, int anchor, bool useClip)
	{
		if (image == null)
		{
			return;
		}
		this.drawRegion(image, 0, 0, mGraphics.getImageWidth(image.image), mGraphics.getImageHeight(image.image), 0, x, y, anchor, useClip);
	}

	// Token: 0x060001C5 RID: 453 RVA: 0x0000BABC File Offset: 0x00009CBC
	public void drawImage(mImage image, int x, int y, bool useClip)
	{
		if (image == null)
		{
			return;
		}
		this.drawRegion(image, 0, 0, mGraphics.getImageWidth(image.image), mGraphics.getImageHeight(image.image), 0, x, y, mGraphics.TOP | mGraphics.LEFT, useClip);
	}

	// Token: 0x060001C6 RID: 454 RVA: 0x0000BB00 File Offset: 0x00009D00
	public void drawRoundRect(int x, int y, int w, int h, int arcWidth, int arcHeight, bool useClip)
	{
		this.drawRect(x, y, w, h, useClip);
	}

	// Token: 0x060001C7 RID: 455 RVA: 0x0000BB10 File Offset: 0x00009D10
	public void fillRoundRect(int x, int y, int width, int height, int arcWidth, int arcHeight, bool useClip)
	{
		this.fillRect(x, y, width, height, useClip);
	}

	// Token: 0x060001C8 RID: 456 RVA: 0x0000BB20 File Offset: 0x00009D20
	public void reset()
	{
		this.isClip = false;
		this.isTranslate = false;
		this.translateX = 0;
		this.translateY = 0;
	}

	// Token: 0x060001C9 RID: 457 RVA: 0x0000BB40 File Offset: 0x00009D40
	public Rect intersectRect(Rect r1, Rect r2)
	{
		float num = r1.x;
		float num2 = r1.y;
		float x = r2.x;
		float y = r2.y;
		float num3 = num;
		num3 += r1.width;
		float num4 = num2;
		num4 += r1.height;
		float num5 = x;
		num5 += r2.width;
		float num6 = y;
		num6 += r2.height;
		if (num < x)
		{
			num = x;
		}
		if (num2 < y)
		{
			num2 = y;
		}
		if (num3 > num5)
		{
			num3 = num5;
		}
		if (num4 > num6)
		{
			num4 = num6;
		}
		num3 -= num;
		num4 -= num2;
		if (num3 < -30000f)
		{
			num3 = -30000f;
		}
		if (num4 < -30000f)
		{
			num4 = -30000f;
		}
		return new Rect(num, num2, (float)((int)num3), (float)((int)num4));
	}

	// Token: 0x060001CA RID: 458 RVA: 0x0000BC18 File Offset: 0x00009E18
	public void drawImageScale(Image image, int x, int y, int w, int h, int tranform)
	{
		GUI.color = Color.red;
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		w *= mGraphics.zoomLevel;
		h *= mGraphics.zoomLevel;
		if (image != null)
		{
			Graphics.DrawTexture(new Rect((float)(x + this.translateX), (float)(y + this.translateY), (float)((tranform != 0) ? (-(float)w) : w), (float)h), image.texture);
		}
	}

	// Token: 0x060001CB RID: 459 RVA: 0x0000BC94 File Offset: 0x00009E94
	public void drawImageSimple(Image image, int x, int y)
	{
		x *= mGraphics.zoomLevel;
		y *= mGraphics.zoomLevel;
		if (image != null)
		{
			Graphics.DrawTexture(new Rect((float)x, (float)y, (float)image.w, (float)image.h), image.texture);
		}
	}

	// Token: 0x060001CC RID: 460 RVA: 0x0000BCDC File Offset: 0x00009EDC
	public static int getImageWidth(Image image)
	{
		return image.getWidth();
	}

	// Token: 0x060001CD RID: 461 RVA: 0x0000BCE4 File Offset: 0x00009EE4
	public static int getImageHeight(Image image)
	{
		return image.getHeight();
	}

	// Token: 0x060001CE RID: 462 RVA: 0x0000BCEC File Offset: 0x00009EEC
	public static bool isNotTranColor(Color color)
	{
		return !(color == Color.clear) && !(color == mGraphics.transParentColor);
	}

	// Token: 0x060001CF RID: 463 RVA: 0x0000BD14 File Offset: 0x00009F14
	public static Image blend(Image img0, float level, int rgb)
	{
		int num = rgb & 255;
		int num2 = rgb >> 8 & 255;
		int num3 = rgb >> 16 & 255;
		float num4 = (float)num / 256f;
		float num5 = (float)num2 / 256f;
		float num6 = (float)num3 / 256f;
		Color color = new Color(num6, num5, num4);
		Color[] pixels = img0.texture.GetPixels();
		float num7 = color.r;
		float num8 = color.g;
		float num9 = color.b;
		for (int i = 0; i < pixels.Length; i++)
		{
			Color color2 = pixels[i];
			if (mGraphics.isNotTranColor(color2))
			{
				float num10 = (num7 - color2.r) * level + color2.r;
				float num11 = (num8 - color2.g) * level + color2.g;
				float num12 = (num9 - color2.b) * level + color2.b;
				if (num10 > 255f)
				{
					num10 = 255f;
				}
				if (num10 < 0f)
				{
					num10 = 0f;
				}
				if (num11 > 255f)
				{
					num11 = 255f;
				}
				if (num11 < 0f)
				{
					num11 = 0f;
				}
				if (num12 < 0f)
				{
					num12 = 0f;
				}
				if (num12 > 255f)
				{
					num12 = 255f;
				}
				pixels[i].r = num10;
				pixels[i].g = num11;
				pixels[i].b = num12;
			}
		}
		Image image = Image.createImage(img0.getRealImageWidth(), img0.getRealImageHeight());
		image.texture.SetPixels(pixels);
		Image.setTextureQuality(image.texture);
		image.texture.Apply();
		Cout.LogError2("BLEND ----------------------------------------------------");
		return image;
	}

	// Token: 0x060001D0 RID: 464 RVA: 0x0000BEF0 File Offset: 0x0000A0F0
	public static int getIntByColor(Color cl)
	{
		float num = cl.r * 255f;
		float num2 = cl.b * 255f;
		float num3 = cl.g * 255f;
		return ((int)num & 255) << 16 | ((int)num3 & 255) << 8 | ((int)num2 & 255);
	}

	// Token: 0x060001D1 RID: 465 RVA: 0x0000BF4C File Offset: 0x0000A14C
	public void fillTriangle(int x1, int x2, int x3, int x4, int x5, int x6, bool isClip)
	{
	}

	// Token: 0x060001D2 RID: 466 RVA: 0x0000BF50 File Offset: 0x0000A150
	public void endClip()
	{
	}

	// Token: 0x04000195 RID: 405
	public const int BASELINE = 64;

	// Token: 0x04000196 RID: 406
	public const int SOLID = 0;

	// Token: 0x04000197 RID: 407
	public const int DOTTED = 1;

	// Token: 0x04000198 RID: 408
	public const int TRANS_MIRROR = 2;

	// Token: 0x04000199 RID: 409
	public const int TRANS_MIRROR_ROT180 = 1;

	// Token: 0x0400019A RID: 410
	public const int TRANS_MIRROR_ROT270 = 4;

	// Token: 0x0400019B RID: 411
	public const int TRANS_MIRROR_ROT90 = 7;

	// Token: 0x0400019C RID: 412
	public const int TRANS_NONE = 0;

	// Token: 0x0400019D RID: 413
	public const int TRANS_ROT180 = 3;

	// Token: 0x0400019E RID: 414
	public const int TRANS_ROT270 = 6;

	// Token: 0x0400019F RID: 415
	public const int TRANS_ROT90 = 5;

	// Token: 0x040001A0 RID: 416
	public static bool isTrue = true;

	// Token: 0x040001A1 RID: 417
	public static bool isFalse = false;

	// Token: 0x040001A2 RID: 418
	public static int HCENTER = 1;

	// Token: 0x040001A3 RID: 419
	public static int VCENTER = 2;

	// Token: 0x040001A4 RID: 420
	public static int LEFT = 4;

	// Token: 0x040001A5 RID: 421
	public static int RIGHT = 8;

	// Token: 0x040001A6 RID: 422
	public static int TOP = 16;

	// Token: 0x040001A7 RID: 423
	public static int BOTTOM = 32;

	// Token: 0x040001A8 RID: 424
	private float r;

	// Token: 0x040001A9 RID: 425
	private float g;

	// Token: 0x040001AA RID: 426
	private float b;

	// Token: 0x040001AB RID: 427
	private float a;

	// Token: 0x040001AC RID: 428
	public int clipX;

	// Token: 0x040001AD RID: 429
	public int clipY;

	// Token: 0x040001AE RID: 430
	public int clipW;

	// Token: 0x040001AF RID: 431
	public int clipH;

	// Token: 0x040001B0 RID: 432
	private bool isClip;

	// Token: 0x040001B1 RID: 433
	private bool isTranslate = true;

	// Token: 0x040001B2 RID: 434
	private int translateX;

	// Token: 0x040001B3 RID: 435
	private int translateY;

	// Token: 0x040001B4 RID: 436
	public static int zoomLevel = 1;

	// Token: 0x040001B5 RID: 437
	public static Hashtable cachedTextures = new Hashtable();

	// Token: 0x040001B6 RID: 438
	public static int addYWhenOpenKeyBoard;

	// Token: 0x040001B7 RID: 439
	public bool isDrawLine;

	// Token: 0x040001B8 RID: 440
	private int clipTX;

	// Token: 0x040001B9 RID: 441
	private int clipTY;

	// Token: 0x040001BA RID: 442
	public mVector totalLine = new mVector();

	// Token: 0x040001BB RID: 443
	private Material lineMaterial;

	// Token: 0x040001BC RID: 444
	private int currentBGColor;

	// Token: 0x040001BD RID: 445
	private Vector2 pos = new Vector2(0f, 0f);

	// Token: 0x040001BE RID: 446
	private Rect rect;

	// Token: 0x040001BF RID: 447
	private Matrix4x4 matrixBackup;

	// Token: 0x040001C0 RID: 448
	private Vector2 pivot;

	// Token: 0x040001C1 RID: 449
	public Vector2 size = new Vector2(128f, 128f);

	// Token: 0x040001C2 RID: 450
	public Vector2 relativePosition = new Vector2(0f, 0f);

	// Token: 0x040001C3 RID: 451
	public Color clTrans;

	// Token: 0x040001C4 RID: 452
	public static Color transParentColor = new Color(1f, 1f, 1f, 0f);
}
