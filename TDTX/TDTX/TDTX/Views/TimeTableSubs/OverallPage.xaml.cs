﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTX.Models;
using TDTX.ViewModels;
using Xamarin.Forms;

namespace TDTX.Views.TimeTableSubs
{
    public partial class OverallPage : ContentPage
    {
        public OverallPage()
        {
            InitializeComponent();
            SemesterListChanged(TimeTablePageViewModel.Instance.SemesterDictionary);
            //use when semester list updated
            MessagingCenter.Subscribe<TimeTablePageViewModel, IDictionary<SemesterInfor, Semester>>(this, "SemesterDictionaryChanged",
                (sender, dic) => SemesterListChanged(dic));
        }

        private async void SemesterListChanged(IDictionary<SemesterInfor, Semester> newDic)
        {
            await Task.Yield();
            int oldIndex = TimeTablePageViewModel.Instance.SelectedSemesterIndex;
            var oldSi = oldIndex >= 0 && oldIndex < TimeTablePageViewModel.Instance.SemesterDictionary.Count ?
                TimeTablePageViewModel.Instance.SemesterDictionary.Keys.ElementAt(oldIndex) : null;
            SemesterPicker.Items.Clear();
            foreach (var si in newDic.Keys)
            {
                SemesterPicker.Items.Add(si.TenHocKy);
                if (Equals(si, oldSi))
                    SemesterPicker.SelectedIndex = SemesterPicker.Items.Count - 1;
            }
        }

        private void SemesterPicker_OnSelectedIndexChanged(object sender, EventArgs e)
        {
            TimeTablePageViewModel.Instance.SelectedSemesterIndex = (sender as Picker).SelectedIndex;
        }
    }
}
