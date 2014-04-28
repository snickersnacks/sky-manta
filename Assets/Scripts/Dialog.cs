using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;

public class Dialog : MonoBehaviour 
{
	public static Dialog i;

	public Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

	void Awake()
	{
		i = this;

		AudioClip[] clippers = Resources.LoadAll<AudioClip>("Dialog/");

		foreach (AudioClip clip in clippers)
			clips.Add(clip.name, clip);
	}

	public void Play(string clipname)
	{
		this.audio.Stop();
		this.audio.clip = clips[clipname];
		this.audio.Play();
	}

	public IEnumerator PlayAndWait(string clipname)
	{
		Play(clipname);
		yield return new WaitForSeconds(this.audio.clip.length);
	}
}
