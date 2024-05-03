using UnityEngine;
using UnityEngine.Video;

public class videoplayercontroller : MonoBehaviour
{
    public VideoPlayer videoPlayer;

    
    // this is a basic function to play the video , was used initially to test the method by me
    public void PlayVideo()
    {
        if (videoPlayer.isPlaying)  // pause or play by checking the current status of the video
        {
            videoPlayer.Stop();
        }
        videoPlayer.Play();
    }
}
