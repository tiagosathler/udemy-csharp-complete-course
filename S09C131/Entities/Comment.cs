﻿namespace S09C131.Entities;

internal class Comment
{
    public string Text { get; set; }

    public Comment(string text)
    {
        Text = text;
    }
}