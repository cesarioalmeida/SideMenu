# SideMenu
Simple WPF SideMenu control

![alt text](http://i.imgur.com/Dj7q2YR.png "SideMenu")

## Use
```
        <controls:SideMenu
            Title="Demo Menu"
            Width="190"
            MinWidth="20"
            IsCollapsible="True">
            <controls:SideMenu.Items>
                <controls:LabelMenuItem Text="MAIN" />
                <controls:ClickableMenuItem
                    Icon="Assets/Home.png"
                    IsChecked="True"
                    Text="DASHBOARD" />
                <controls:ClickableMenuItem Icon="Assets/search.png" Text="SEARCH" />
                <controls:SeparatorMenuItem />
                <controls:LabelMenuItem Text="MORE" />
                <controls:ClickableMenuItem Icon="Assets/person.png" Text="USER" />
                <controls:ClickableMenuItem Icon="Assets/favorite.png" Text="FAVORITES" />
            </controls:SideMenu.Items>
            <controls:SideMenu.BarItems>
                <controls:SelectableBarButtonMenuItem Icon="Assets/list.png" />
                <controls:BarButtonMenuItem Icon="Assets/reload.png" />
            </controls:SideMenu.BarItems>
        </controls:SideMenu>
```
