# SideMenu
Simple WPF SideMenu control

![alt text](http://i.imgur.com/Dj7q2YR.png "SideMenu")

## Use
```
<controls:SideMenu Width="190" Title="Demo Menu">
            <controls:SideMenu.Items>
                <controls:LabelMenuItem Text="MAIN"/>
                <controls:ClickableMenuItem Text="DASHBOARD" Icon="Assets/Home.png" IsChecked="True" />
                <controls:ClickableMenuItem Text="SEARCH" Icon="Assets/search.png" />
                <controls:SeparatorMenuItem />
                <controls:LabelMenuItem Text="MORE"/>
                <controls:ClickableMenuItem Text="USER" Icon="Assets/person.png" />
                <controls:ClickableMenuItem Text="FAVORITES" Icon="Assets/favorite.png" />
            </controls:SideMenu.Items>
            <controls:SideMenu.BarItems>
                <controls:SelectableBarButtonMenuItem Icon="Assets/list.png" />
                <controls:BarButtonMenuItem Icon="Assets/reload.png" />
            </controls:SideMenu.BarItems>
        </controls:SideMenu>
```
