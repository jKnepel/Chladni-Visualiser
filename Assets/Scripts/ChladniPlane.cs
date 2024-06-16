using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class ChladniPlane : MonoBehaviour
{
    [SerializeField] private int _xSize = 10;
    [SerializeField] private int _ySize = 10;
    [SerializeField] private Material _chladniMaterial;

    private Mesh        _mesh;
    private Vector3[]   _vertices;
    private int[]       _triangles;

	private void Awake()
	{
        GetComponent<MeshFilter>().mesh = _mesh = new Mesh();
        _mesh.name = "ChladniPlane";

        _vertices = new Vector3[(_xSize + 1) * (_ySize + 1)];
        for (int i = 0, y = 0; y <= _ySize; y += _ySize / 10)
            for (var x = 0; x <= _xSize; x += _xSize / 10, i++)
                _vertices[i] = new(x - _xSize / 2f, 0, y - _ySize / 2f);
        
        _mesh.vertices = _vertices;
        _triangles = new int[_xSize * _ySize * 6];
        for (int i = 0, j = 0, y = 0; y < _ySize; y++, j++)
		{
            for (int x = 0; x < _xSize; x++, i += 6, j++)
			{
                _triangles[i] = j;
                _triangles[i + 3] = _triangles[i + 2] = j + 1;
                _triangles[i + 4] = _triangles[i + 1] = j + _xSize + 1;
                _triangles[i + 5] = j + _xSize + 2;
            }
		}
        _mesh.triangles = _triangles;

        GetComponent<MeshRenderer>().material = _chladniMaterial;
	}
}
