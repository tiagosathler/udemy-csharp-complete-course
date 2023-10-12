using System.Text;

namespace S09C131.Entities;

internal class Post
{
    public DateTime Moment { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public int Likes { get; set; }
    public List<Comment> Comments { get; } = new();

    public Post(DateTime moment, string title, string content, int likes)
    {
        Moment = moment;
        Title = title;
        Content = content;
        Likes = likes;
    }

    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    public void RemoveComment(Comment comment)
    {
        Comments.Remove(comment);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new();

        stringBuilder
            .AppendLine(Title)
            .Append(Likes).Append(" Likes - ").AppendLine(Moment.ToString(Program.DATE_TIME_FORMAT))
            .AppendLine(Content);

        if (Comments.Count > 0)
        {
            stringBuilder
                .Append("Comments (").Append(Comments.Count).AppendLine("):");

            foreach (Comment comment in Comments)
            {
                stringBuilder
                    .Append(" - ").AppendLine(comment.Text);
            }
        }
        else
        {
            stringBuilder.AppendLine("There aren't comments!");
        }

        return stringBuilder.ToString();
    }
}