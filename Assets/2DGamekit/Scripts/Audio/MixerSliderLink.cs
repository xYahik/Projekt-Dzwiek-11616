using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

namespace Gamekit2D
{
    [RequireComponent(typeof(Slider))]
    public class MixerSliderLink : MonoBehaviour
    {
        public AudioMixer mixer;
        public string mixerParameter;
        public float maxAttenuation = 0.0f;
        public float minAttenuation = -80.0f;
        
        public string busString = "";
        FMOD.Studio.VCA vca;
        private float volume;
        protected Slider m_Slider;


        void Awake ()
        {
            m_Slider = GetComponent<Slider>();
            vca = FMODUnity.RuntimeManager.GetVCA(busString);
            float value,maxvolume;
            /*mixer.GetFloat(mixerParameter, out value);
            */
            vca.getVolume(out value, out maxvolume);

            //m_Slider.value = (value - minAttenuation) / (maxAttenuation - minAttenuation);
            m_Slider.value = value;
            m_Slider.onValueChanged.AddListener(SliderValueChange);
        }


        void SliderValueChange(float value)
        {
            //Debug.LogWarning(value);
            //mixer.SetFloat(mixerParameter, minAttenuation + value * (maxAttenuation - minAttenuation));
            //volume = Mathf.Pow(10.0f, value / 20f);
            volume = value;
            vca.setVolume(volume);
        }
    }
}