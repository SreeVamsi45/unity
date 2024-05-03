using UnityEngine;
using UnityEngine.Video;

[RequireComponent(typeof(Renderer))]
public class multivideorenderer : MonoBehaviour
{
    public VideoClip[] videoClips; // Assign the Video Clips in the Inspector
    private VideoPlayer videoPlayer;
    public RenderTexture renderTexture; // texture which displays or renders the videos
    private int currentVideoIndex = -1; // Index of the currently playing video, -1 means no video is playing

    void Start()
    {
        InitializeVideoPlayer(); // player is initialized
    }

    void InitializeVideoPlayer()
    {
        videoPlayer = gameObject.AddComponent<VideoPlayer>();
        videoPlayer.playOnAwake = false;

        // Create a Render Texture with the same dimensions as the video
        renderTexture = new RenderTexture((int)videoPlayer.clip.width, (int)videoPlayer.clip.height, 0);
        renderTexture.Create();

        // Assign the Render Texture to the material of the Renderer component
        Renderer renderer = GetComponent<Renderer>();
        renderer.material.mainTexture = renderTexture;

        // Set the Target Texture of the Video Player to the Render Texture
        videoPlayer.targetTexture = renderTexture;
    }

    public void PlayVideo(int index)
    {
        if (index >= 0 && index < videoClips.Length)  // checks the index using the current video index to see what video is being played 1,2 or 3
        {
            if (index != currentVideoIndex || !videoPlayer.isPlaying)
            {
                videoPlayer.clip = videoClips[index];
                videoPlayer.Play();
                currentVideoIndex = index;
            }
        }
        else
        {
            Debug.LogError("Invalid video index.");
        }
    }

    public void Pause()   // to pause the video
    {
        if (currentVideoIndex != -1)
        {
            videoPlayer.Pause();
        }
       
    }
    public void Resume() // to resume the video
    {
        if (currentVideoIndex != -1)
        {
            videoPlayer.Play();
        }
    }

    public void Stop() // to stop the video
    {
        if (currentVideoIndex != -1)
        {
            videoPlayer.Stop();
            currentVideoIndex = -1;
        }
    }

    public void SeekForward(float seconds) // to seek forward , we can decide by how many seconds
    {
        if (currentVideoIndex != -1)
        {
            videoPlayer.time += seconds;
        }
    }

    public void SeekBackward(float seconds)// to seek backward , we can decide by how many seconds
    {
        if (currentVideoIndex != -1)
        {
            videoPlayer.time -= seconds;
        }
    }
}
