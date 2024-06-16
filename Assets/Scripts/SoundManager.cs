using UnityEngine;
using UnityEngine.VFX;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour
{
    [SerializeField] private VisualEffect chladniSimulation;
    [SerializeField] private int _frequency;

    private float _sampleRate = 44100;
    private float _waveLength = 2;
    private int _time;

	private void Update()
	{
        _frequency = (int)Mathf.Pow(chladniSimulation.GetInt("m") + 2 * chladniSimulation.GetInt("n"), 2);
    }

	private void OnAudioFilterRead(float[] data, int channels)
	{
        for (var i = 0; i < data.Length; i += channels)
        {
            data[i] = CreateSine(_time, _frequency, _sampleRate);

            _time++;
            if (_time >= _sampleRate * _waveLength)
                _time = 0;
        }
    }

    private static float CreateSine(int timeIndex, float frequency, float sampleRate)
    {
        return Mathf.Sin(2 * Mathf.PI * timeIndex * frequency / sampleRate);
    }
}
