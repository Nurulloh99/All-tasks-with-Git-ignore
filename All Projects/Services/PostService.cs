using CRUD_Post.Models;

namespace CRUD_Post.Services;

public class PostService
{
    private List<Post> posts;

    public PostService()
    {
        posts = new List<Post>();
    }


    public Post AddedPost(Post postName)
    {
        postName.Id = Guid.NewGuid();
        posts.Add(postName);
        return postName;
    }



    public Post GetPostById(Guid postId)
    {
        foreach (var post in posts)
        {
            if (post.Id == postId)
            {
                return post;
            }
        }
        return null;
    }




    public bool DeletedPost(Guid IdforRemove)
    {
        var postDb = GetPostById(IdforRemove);

        if(postDb is null)
        {
            return false;
        }

        posts.Remove(postDb);
        return true;
    }




    public bool UpdatedPost(Post updatingPost)
    {
        var postForUpdateInDb = GetPostById(updatingPost.Id);

        if(postForUpdateInDb is null)
        {
            return false;
        }

        var index = posts.IndexOf(postForUpdateInDb);
        posts[index] = updatingPost;
        return true;
    }



    public List<Post> GetAllPosts()
    {
        return posts;
    }






    public Post GetMostViewedPost()
    {
        var responsePost = new Post();
        var maxCount = 0;

        foreach (var post in posts)
        {
            if (maxCount < post.ViewerNames.Count)
            {
                responsePost = post;
                maxCount = post.ViewerNames.Count;
            }
        }

        return responsePost;
    }


    public Post GetMostLikedPost()
    {
        var responsePost = new Post();
        var maxCount = 0;

        foreach (var post in posts)
        {
            if (maxCount < post.QuantityLikes)
            {
                responsePost = post;
                maxCount = post.QuantityLikes;
            }
        }
        return responsePost;
    }



    public List<Post> GetPostsByComment(string comment)
    {
        var collection = new List<Post>();

        foreach(var check in posts)
        {
            if (check.Comments.Contains(comment))
            {
                collection.Add(check);
            }
        }
        return collection;


        //for(var i = 0; i < posts.Count; i++)
        //{
        //    for(var j = 0; j < posts[i].Comments.Count; i++)
        //    {
        //        if (posts[i].Comments[j] == comment)
        //        {
        //            collection.Add(posts[i]);
        //        }
        //    }
        //}
        //return collection;
    }


    public Post GetMostCommentedPost()
    {
        var responsePost = new Post();
        var maxCount = 0;

        foreach (var post in posts)
        {
            if (maxCount < post.Comments.Count)
            {
                responsePost = post;
                maxCount = post.Comments.Count;
            }
        }
        return responsePost;
    }




    public bool AddCommentedPost(Guid postId, string postText)
    {
        var posst = GetPostById(postId);

        if(posst is null)
        {
            return false;
        }
        posst.Comments.Add(postText);
        return true;
    }




    public bool AddLikesPost(Guid postId)
    {
        var posst = GetPostById(postId);

        if (posst is null)
        {
            return false;
        }
        posst.QuantityLikes++;
        return true;
    }


    
    public bool AddNewViewerName(Guid postID, string viewer)
    {
        var posst = GetPostById(postID);

        if(posst is null)
        {
            return false;
        }
        posst.ViewerNames.Add(viewer);
        return true;
    }














}
