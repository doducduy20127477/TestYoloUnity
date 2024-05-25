//using UnityEngine;
//using UnityEngine.UI;
//using Klak.TestTools;
//using YoloV4Tiny;

//sealed class Visualizer : MonoBehaviour
//{
//    #region Editable attributes

//    [SerializeField] ImageSource _source = null;
//    [SerializeField, Range(0, 1)] float _threshold = 0.5f;
//    [SerializeField] ResourceSet _resources = null;
//    [SerializeField] RawImage _preview = null;
//    [SerializeField] Marker _markerPrefab = null;

//    #endregion

//    #region Internal objects

//    ObjectDetector _detector;
//    Marker[] _markers = new Marker[50];

//    #endregion

//    #region MonoBehaviour implementation

//    void Start()
//    {
//        _detector = new ObjectDetector(_resources);
//        for (var i = 0; i < _markers.Length; i++)
//            _markers[i] = Instantiate(_markerPrefab, _preview.transform);
//    }

//    void OnDisable()
//      => _detector.Dispose();

//    void OnDestroy()
//    {
//        for (var i = 0; i < _markers.Length; i++) Destroy(_markers[i]);
//    }

//    void Update()
//    {
//        _detector.ProcessImage(_source.Texture, _threshold);

//        var i = 0;
//        foreach (var d in _detector.Detections)
//        {
//            if (i == _markers.Length) break;
//            _markers[i++].SetAttributes(d);
//        }

//        for (; i < _markers.Length; i++) _markers[i].Hide();

//        _preview.texture = _source.Texture;
//    }

//    #endregion
//}

using UnityEngine;
using UnityEngine.UI;
using Klak.TestTools;
using YoloV4Tiny;

internal sealed class Visualizer : MonoBehaviour
{
    #region Editable attributes

    [SerializeField] private ImageSource _source = null;
    [SerializeField, Range(0, 1)] private float _threshold = 0.5f;
    [SerializeField] private ResourceSet _resources = null;
    [SerializeField] private RawImage _preview = null;
    [SerializeField] private Marker _markerPrefab = null;

    #endregion Editable attributes

    #region Internal objects

    private ObjectDetector _detector;
    private Marker[] _markers = new Marker[50];

    #endregion Internal objects

    #region MonoBehaviour implementation

    private void Start()
    {
        _detector = new ObjectDetector(_resources);
        for (var i = 0; i < _markers.Length; i++)
            _markers[i] = Instantiate(_markerPrefab, _preview.transform);
    }

    private void OnDisable()
      => _detector.Dispose();

    private void OnDestroy()
    {
        for (var i = 0; i < _markers.Length; i++) Destroy(_markers[i]);
    }

    private void Update()
    {
        _detector.ProcessImage(_source.Texture, _threshold);

        var i = 0;
        foreach (var d in _detector.Detections)
        {
            if (i == _markers.Length) break;
            _markers[i++].SetAttributes(d);
        }

        for (; i < _markers.Length; i++) _markers[i].Hide();

        _preview.texture = _source.Texture;
    }

    #endregion MonoBehaviour implementation
}