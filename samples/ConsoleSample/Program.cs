﻿using System;
using System.Collections.Generic;
using System.Xml;
using WxrNet;

namespace ConsoleSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var comment = new Comment();
            comment.Id = "1212121";
            comment.AuthorEmail = "foo@bar.com";
            comment.AuthorFullName = "John Doe";
            comment.AuthorUrl = "http://example.com";
            comment.CommentDateInGmt = DateTime.Now.AddDays(-100);
            comment.Content = new XmlDocument().CreateCDataSection("lorem ipsum lorem");
            comment.IpAddress = "127.0.0.1";
            comment.IsApproved = true;

            var post = new Post();
            post.Id = "1";
            post.Title = "Foo Bar";
            post.Content = new XmlDocument().CreateCDataSection("lorem ipsum <a href=\"http://example.com\">my site</a> loremlorem ipsum loremlorem ipsum lorem");
            post.IsCommentsOpen = true;
            post.Link = "http://example.com/foo-bar";
            post.PostDateInGmt = DateTime.Now.AddDays(-150);
            post.Comments = new List<Comment> { comment };

            var wxr = new Wxr();
            wxr.Site = new Site { Posts = new List<Post> { post } };

            var serializedContent = WxrSerializer.Serialize(wxr);

            Console.WriteLine(serializedContent);
        }
    }
}
