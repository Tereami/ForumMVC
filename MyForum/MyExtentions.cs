using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using MyForum.Models;
using MyForum.ViewModels.Index;

namespace MyForum
{
	public static class MyExtensions
	{

		public static ViewModels.Index.IndexViewModel.MessageViewModel CreateLastMessage(this Message m)
		{
			if (m == null)
				return null;
			if (m.Theme.IsHidden)
				return null;

			Guid msgId = m.Id;
			string text = m.Text;
			User author = m.Author;
            if (author == null)
            {
				string errmsg = "MessageViewModel failed! User author is null!";
                Debug.WriteLine(errmsg);
				throw new Exception(errmsg);
            }
            Guid authorid = author.Id;
			string username = author.UserName;
			Theme th = m.Theme;
            if (th == null)
            {
                string errmsg = "MessageViewModel failed! Theme is null!";
                Debug.WriteLine(errmsg);
                throw new Exception(errmsg);
            }
            Guid themeId = th.Id;
			DateTime time = m.CreatingTime;
			IndexViewModel.MessageViewModel viewModel = new IndexViewModel.MessageViewModel()
			{
				MessageId = msgId,
				AuthorId = authorid,
				AuthorName = username,
				Text = text,
				ThemeId = themeId,
				CreatingTime = time,
			};

			return viewModel;
		}
	}
}
