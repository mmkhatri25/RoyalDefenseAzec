using System;
using tk2dRuntime;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[AddComponentMenu("2D Toolkit/Text/tk2dTextMesh")]
[RequireComponent(typeof(MeshFilter))]
[ExecuteInEditMode]
public class tk2dTextMesh : MonoBehaviour, ISpriteCollectionForceBuild
{
	[Flags]
	private enum UpdateFlags
	{
		UpdateNone = 0x0,
		UpdateText = 0x1,
		UpdateColors = 0x2,
		UpdateBuffers = 0x4
	}

	[SerializeField]
	private tk2dFontData _font;

	[SerializeField]
	private string _text = string.Empty;

	[SerializeField]
	private Color _color = Color.white;

	[SerializeField]
	private Color _color2 = Color.white;

	[SerializeField]
	private bool _useGradient;

	[SerializeField]
	private int _textureGradient;

	[SerializeField]
	private TextAnchor _anchor = TextAnchor.LowerLeft;

	[SerializeField]
	private Vector3 _scale = new Vector3(1f, 1f, 1f);

	[SerializeField]
	private bool _kerning;

	[SerializeField]
	private int _maxChars = 16;

	[SerializeField]
	private bool _inlineStyling;

	public bool pixelPerfect;

	public float spacing;

	public float lineSpacing;

	private Vector3[] vertices;

	private Vector2[] uvs;

	private Vector2[] uv2;

	private Color[] colors;

	private UpdateFlags updateFlags = UpdateFlags.UpdateBuffers;

	private Mesh mesh;

	private MeshFilter meshFilter;

	public tk2dFontData font
	{
		get
		{
			return _font;
		}
		set
		{
			_font = value;
			updateFlags |= UpdateFlags.UpdateText;
			if (GetComponent<Renderer>().sharedMaterial != _font.material)
			{
				GetComponent<Renderer>().material = _font.material;
			}
		}
	}

	public string text
	{
		get
		{
			return _text;
		}
		set
		{
			_text = value;
			updateFlags |= UpdateFlags.UpdateText;
		}
	}

	public Color color
	{
		get
		{
			return _color;
		}
		set
		{
			_color = value;
			updateFlags |= UpdateFlags.UpdateColors;
		}
	}

	public Color color2
	{
		get
		{
			return _color2;
		}
		set
		{
			_color2 = value;
			updateFlags |= UpdateFlags.UpdateColors;
		}
	}

	public bool useGradient
	{
		get
		{
			return _useGradient;
		}
		set
		{
			_useGradient = value;
			updateFlags |= UpdateFlags.UpdateColors;
		}
	}

	public TextAnchor anchor
	{
		get
		{
			return _anchor;
		}
		set
		{
			_anchor = value;
			updateFlags |= UpdateFlags.UpdateText;
		}
	}

	public Vector3 scale
	{
		get
		{
			return _scale;
		}
		set
		{
			_scale = value;
			updateFlags |= UpdateFlags.UpdateText;
		}
	}

	public bool kerning
	{
		get
		{
			return _kerning;
		}
		set
		{
			_kerning = value;
			updateFlags |= UpdateFlags.UpdateText;
		}
	}

	public int maxChars
	{
		get
		{
			return _maxChars;
		}
		set
		{
			_maxChars = value;
			updateFlags |= UpdateFlags.UpdateBuffers;
		}
	}

	public int textureGradient
	{
		get
		{
			return _textureGradient;
		}
		set
		{
			_textureGradient = value % font.gradientCount;
			updateFlags |= UpdateFlags.UpdateText;
		}
	}

	public bool inlineStyling
	{
		get
		{
			return _inlineStyling;
		}
		set
		{
			_inlineStyling = value;
			updateFlags |= UpdateFlags.UpdateText;
		}
	}

	public float Spacing
	{
		get
		{
			return spacing;
		}
		set
		{
			if (spacing != value)
			{
				spacing = value;
				updateFlags |= UpdateFlags.UpdateText;
			}
		}
	}

	public float LineSpacing
	{
		get
		{
			return lineSpacing;
		}
		set
		{
			if (lineSpacing != value)
			{
				lineSpacing = value;
				updateFlags |= UpdateFlags.UpdateText;
			}
		}
	}

	private bool useInlineStyling => inlineStyling && _font.textureGradients;

	private void Awake()
	{
		if (pixelPerfect)
		{
			MakePixelPerfect();
		}
		updateFlags = UpdateFlags.UpdateBuffers;
		Init();
	}

	protected void OnDestroy()
	{
		if (meshFilter == null)
		{
			meshFilter = GetComponent<MeshFilter>();
		}
		if (meshFilter != null)
		{
			mesh = meshFilter.sharedMesh;
		}
		if ((bool)mesh)
		{
			UnityEngine.Object.DestroyImmediate(mesh, allowDestroyingAssets: true);
			meshFilter.mesh = null;
		}
	}

	public int NumDrawnCharacters()
	{
		bool useInlineStyling = this.useInlineStyling;
		int num = 0;
		for (int i = 0; i < _text.Length && num < _maxChars; i++)
		{
			int num2 = _text[i];
			if (_font.useDictionary)
			{
				if (!_font.charDict.ContainsKey(num2))
				{
					num2 = 0;
				}
			}
			else if (num2 >= _font.chars.Length)
			{
				num2 = 0;
			}
			if (num2 == 10)
			{
				continue;
			}
			if (useInlineStyling && num2 == 94 && i + 1 < _text.Length)
			{
				i++;
				if (_text[i] != '^')
				{
					continue;
				}
			}
			num++;
		}
		return num;
	}

	public int NumTotalCharacters()
	{
		bool useInlineStyling = this.useInlineStyling;
		int num = 0;
		for (int i = 0; i < _text.Length; i++)
		{
			int num2 = _text[i];
			if (_font.useDictionary)
			{
				if (!_font.charDict.ContainsKey(num2))
				{
					num2 = 0;
				}
			}
			else if (num2 >= _font.chars.Length)
			{
				num2 = 0;
			}
			if (num2 == 10)
			{
				continue;
			}
			if (useInlineStyling && num2 == 94 && i + 1 < _text.Length)
			{
				i++;
				if (_text[i] != '^')
				{
					continue;
				}
			}
			num++;
		}
		return num;
	}

	private void PostAlignTextData(int targetStart, int targetEnd, float offsetX)
	{
		for (int i = targetStart * 4; i < targetEnd * 4; i++)
		{
			Vector3 vector = vertices[i];
			vector.x += offsetX;
			vertices[i] = vector;
		}
	}

	private int FillTextData()
	{
		Vector2 a = new Vector2((float)_textureGradient / (float)font.gradientCount, 0f);
		Vector2 meshDimensionsForString = GetMeshDimensionsForString(_text);
		float yAnchorForHeight = GetYAnchorForHeight(meshDimensionsForString.y);
		bool useInlineStyling = this.useInlineStyling;
		float num = 0f;
		float num2 = 0f;
		int num3 = 0;
		int num4 = 0;
		for (int i = 0; i < _text.Length && num3 < _maxChars; i++)
		{
			int num5 = _text[i];
			tk2dFontChar tk2dFontChar;
			if (_font.useDictionary)
			{
				if (!_font.charDict.ContainsKey(num5))
				{
					num5 = 0;
				}
				tk2dFontChar = _font.charDict[num5];
			}
			else
			{
				if (num5 >= _font.chars.Length)
				{
					num5 = 0;
				}
				tk2dFontChar = _font.chars[num5];
			}
			if (num5 == 10)
			{
				float lineWidth = num;
				int targetEnd = num3;
				if (num4 != num3)
				{
					float xAnchorForWidth = GetXAnchorForWidth(lineWidth);
					PostAlignTextData(num4, targetEnd, xAnchorForWidth);
				}
				num4 = num3;
				num = 0f;
				num2 -= (_font.lineHeight + lineSpacing) * _scale.y;
				continue;
			}
			if (useInlineStyling && num5 == 94 && i + 1 < _text.Length)
			{
				i++;
				if (_text[i] != '^')
				{
					int num6 = _text[i] - 48;
					a = new Vector2((float)num6 / (float)font.gradientCount, 0f);
					continue;
				}
			}
			vertices[num3 * 4] = new Vector3(num + tk2dFontChar.p0.x * _scale.x, yAnchorForHeight + num2 + tk2dFontChar.p0.y * _scale.y, 0f);
			vertices[num3 * 4 + 1] = new Vector3(num + tk2dFontChar.p1.x * _scale.x, yAnchorForHeight + num2 + tk2dFontChar.p0.y * _scale.y, 0f);
			vertices[num3 * 4 + 2] = new Vector3(num + tk2dFontChar.p0.x * _scale.x, yAnchorForHeight + num2 + tk2dFontChar.p1.y * _scale.y, 0f);
			vertices[num3 * 4 + 3] = new Vector3(num + tk2dFontChar.p1.x * _scale.x, yAnchorForHeight + num2 + tk2dFontChar.p1.y * _scale.y, 0f);
			if (tk2dFontChar.flipped)
			{
				uvs[num3 * 4] = new Vector2(tk2dFontChar.uv1.x, tk2dFontChar.uv1.y);
				uvs[num3 * 4 + 1] = new Vector2(tk2dFontChar.uv1.x, tk2dFontChar.uv0.y);
				uvs[num3 * 4 + 2] = new Vector2(tk2dFontChar.uv0.x, tk2dFontChar.uv1.y);
				uvs[num3 * 4 + 3] = new Vector2(tk2dFontChar.uv0.x, tk2dFontChar.uv0.y);
			}
			else
			{
				uvs[num3 * 4] = new Vector2(tk2dFontChar.uv0.x, tk2dFontChar.uv0.y);
				uvs[num3 * 4 + 1] = new Vector2(tk2dFontChar.uv1.x, tk2dFontChar.uv0.y);
				uvs[num3 * 4 + 2] = new Vector2(tk2dFontChar.uv0.x, tk2dFontChar.uv1.y);
				uvs[num3 * 4 + 3] = new Vector2(tk2dFontChar.uv1.x, tk2dFontChar.uv1.y);
			}
			if (_font.textureGradients)
			{
				uv2[num3 * 4] = a + tk2dFontChar.gradientUv[0];
				uv2[num3 * 4 + 1] = a + tk2dFontChar.gradientUv[1];
				uv2[num3 * 4 + 2] = a + tk2dFontChar.gradientUv[2];
				uv2[num3 * 4 + 3] = a + tk2dFontChar.gradientUv[3];
			}
			num += (tk2dFontChar.advance + spacing) * _scale.x;
			if (_kerning && i < _text.Length - 1)
			{
				tk2dFontKerning[] kerning = _font.kerning;
				foreach (tk2dFontKerning tk2dFontKerning in kerning)
				{
					if (tk2dFontKerning.c0 == _text[i] && tk2dFontKerning.c1 == _text[i + 1])
					{
						num += tk2dFontKerning.amount * _scale.x;
						break;
					}
				}
			}
			num3++;
		}
		if (num4 != num3)
		{
			float lineWidth2 = num;
			int targetEnd2 = num3;
			float xAnchorForWidth2 = GetXAnchorForWidth(lineWidth2);
			PostAlignTextData(num4, targetEnd2, xAnchorForWidth2);
		}
		return num3;
	}

	public void Init(bool force)
	{
		if (force)
		{
			updateFlags |= UpdateFlags.UpdateBuffers;
		}
		Init();
	}

	public void Init()
	{
		if (!_font || ((updateFlags & UpdateFlags.UpdateBuffers) == UpdateFlags.UpdateNone && !(mesh == null)))
		{
			return;
		}
		_font.InitDictionary();
		Color color = _color;
		Color color2 = (!_useGradient) ? _color : _color2;
		vertices = new Vector3[_maxChars * 4];
		uvs = new Vector2[_maxChars * 4];
		colors = new Color[_maxChars * 4];
		if (_font.textureGradients)
		{
			uv2 = new Vector2[_maxChars * 4];
		}
		int[] array = new int[_maxChars * 6];
		int num = FillTextData();
		for (int i = 0; i < num; i++)
		{
			colors[i * 4] = (colors[i * 4 + 1] = color);
			colors[i * 4 + 2] = (colors[i * 4 + 3] = color2);
			array[i * 6] = i * 4;
			array[i * 6 + 1] = i * 4 + 1;
			array[i * 6 + 2] = i * 4 + 3;
			array[i * 6 + 3] = i * 4 + 2;
			array[i * 6 + 4] = i * 4;
			array[i * 6 + 5] = i * 4 + 3;
		}
		for (int j = num; j < _maxChars; j++)
		{
			vertices[j * 4] = (vertices[j * 4 + 1] = (vertices[j * 4 + 2] = (vertices[j * 4 + 3] = Vector3.zero)));
			uvs[j * 4] = (uvs[j * 4 + 1] = (uvs[j * 4 + 2] = (uvs[j * 4 + 3] = Vector2.zero)));
			if (_font.textureGradients)
			{
				uv2[j * 4] = (uv2[j * 4 + 1] = (uv2[j * 4 + 2] = (uv2[j * 4 + 3] = Vector2.zero)));
			}
			colors[j * 4] = (colors[j * 4 + 1] = color);
			colors[j * 4 + 2] = (colors[j * 4 + 3] = color2);
			array[j * 6] = j * 4;
			array[j * 6 + 1] = j * 4 + 1;
			array[j * 6 + 2] = j * 4 + 3;
			array[j * 6 + 3] = j * 4 + 2;
			array[j * 6 + 4] = j * 4;
			array[j * 6 + 5] = j * 4 + 3;
		}
		if (mesh == null)
		{
			if (meshFilter == null)
			{
				meshFilter = GetComponent<MeshFilter>();
			}
			mesh = new Mesh();
			meshFilter.mesh = mesh;
		}
		mesh.vertices = vertices;
		mesh.uv = uvs;
		if (font.textureGradients)
		{
			mesh.uv2 = uv2;
		}
		mesh.triangles = array;
		mesh.colors = colors;
		mesh.RecalculateBounds();
		updateFlags = UpdateFlags.UpdateNone;
	}

	public void Commit()
	{
		_font.InitDictionary();
		if ((updateFlags & UpdateFlags.UpdateBuffers) != 0 || mesh == null)
		{
			Init();
		}
		else
		{
			if ((updateFlags & UpdateFlags.UpdateText) != 0)
			{
				int num = FillTextData();
				for (int i = num; i < _maxChars; i++)
				{
					vertices[i * 4] = (vertices[i * 4 + 1] = (vertices[i * 4 + 2] = (vertices[i * 4 + 3] = Vector3.zero)));
				}
				mesh.vertices = vertices;
				mesh.uv = uvs;
				if (font.textureGradients)
				{
					mesh.uv2 = uv2;
				}
			}
			if ((updateFlags & UpdateFlags.UpdateColors) != 0)
			{
				Color color = _color;
				Color color2 = (!_useGradient) ? _color : _color2;
				for (int j = 0; j < colors.Length; j += 4)
				{
					colors[j] = (colors[j + 1] = color);
					colors[j + 2] = (colors[j + 3] = color2);
				}
				mesh.colors = colors;
			}
		}
		updateFlags = UpdateFlags.UpdateNone;
	}

	private Vector2 GetMeshDimensionsForString(string str)
	{
		bool useInlineStyling = this.useInlineStyling;
		float b = 0f;
		float num = 0f;
		float num2 = 0f;
		int num3 = 0;
		for (int i = 0; i < str.Length && num3 < _maxChars; i++)
		{
			int num4 = str[i];
			if (num4 == 10)
			{
				b = Mathf.Max(num, b);
				num = 0f;
				num2 -= (_font.lineHeight + lineSpacing) * _scale.y;
				continue;
			}
			if (useInlineStyling && num4 == 94 && i + 1 < str.Length)
			{
				i++;
				if (str[i] != '^')
				{
					continue;
				}
			}
			tk2dFontChar tk2dFontChar;
			if (_font.useDictionary)
			{
				if (!_font.charDict.ContainsKey(num4))
				{
					num4 = 0;
				}
				tk2dFontChar = _font.charDict[num4];
			}
			else
			{
				if (num4 >= _font.chars.Length)
				{
					num4 = 0;
				}
				tk2dFontChar = _font.chars[num4];
			}
			num += (tk2dFontChar.advance + spacing) * _scale.x;
			if (_kerning && i < str.Length - 1)
			{
				tk2dFontKerning[] kerning = _font.kerning;
				foreach (tk2dFontKerning tk2dFontKerning in kerning)
				{
					if (tk2dFontKerning.c0 == str[i] && tk2dFontKerning.c1 == str[i + 1])
					{
						num += tk2dFontKerning.amount * _scale.x;
						break;
					}
				}
			}
			num3++;
		}
		b = Mathf.Max(num, b);
		num2 -= (_font.lineHeight + lineSpacing) * _scale.y;
		return new Vector2(b, num2);
	}

	private float GetYAnchorForHeight(float textHeight)
	{
		int num = (int)_anchor / 3;
		float num2 = (_font.lineHeight + lineSpacing) * _scale.y;
		switch (num)
		{
		case 0:
			return 0f - num2;
		case 1:
			return (0f - textHeight) / 2f - num2;
		case 2:
			return 0f - textHeight - num2;
		default:
			return 0f - num2;
		}
	}

	private float GetXAnchorForWidth(float lineWidth)
	{
		switch ((int)_anchor % 3)
		{
		case 0:
			return 0f;
		case 1:
			return (0f - lineWidth) / 2f;
		case 2:
			return 0f - lineWidth;
		default:
			return 0f;
		}
	}

	public void MakePixelPerfect()
	{
		float num = 1f;
		tk2dPixelPerfectHelper inst = tk2dPixelPerfectHelper.inst;
		if ((bool)inst)
		{
			if (inst.CameraIsOrtho)
			{
				num = inst.scaleK;
			}
			else
			{
				float scaleK = inst.scaleK;
				float scaleD = inst.scaleD;
				Vector3 position = base.transform.position;
				num = scaleK + scaleD * position.z;
			}
		}
		else if (tk2dCamera.inst != null)
		{
			if (font.version < 1)
			{
				UnityEngine.Debug.LogError("Need to rebuild font.");
			}
			num = font.invOrthoSize * font.halfTargetHeight;
		}
		else if ((bool)Camera.main)
		{
			if (Camera.main.orthographic)
			{
				num = Camera.main.orthographicSize;
			}
			else
			{
				Vector3 position2 = base.transform.position;
				float z = position2.z;
				Vector3 position3 = Camera.main.transform.position;
				float zdist = z - position3.z;
				num = tk2dPixelPerfectHelper.CalculateScaleForPerspectiveCamera(Camera.main.fieldOfView, zdist);
			}
		}
		Vector3 scale = this.scale;
		float x = Mathf.Sign(scale.x) * num;
		Vector3 scale2 = this.scale;
		float y = Mathf.Sign(scale2.y) * num;
		Vector3 scale3 = this.scale;
		this.scale = new Vector3(x, y, Mathf.Sign(scale3.z) * num);
	}

	public bool UsesSpriteCollection(tk2dSpriteCollectionData spriteCollection)
	{
		return true;
	}

	public void ForceBuild()
	{
		Init(force: true);
	}
}
