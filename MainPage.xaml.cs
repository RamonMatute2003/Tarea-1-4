

using Plugin.Media;
using Tarea_1_4.Views;

namespace Tarea_1_4 {
    public partial class MainPage:ContentPage {

        public MainPage() {
            InitializeComponent();

        }

        Plugin.Media.Abstractions.MediaFile photo_camera = null;

        public byte[] image_to_array_byte() {
            if(photo_camera!=null) {
                using(MemoryStream memory = new MemoryStream()) {
                    Stream stream = photo_camera.GetStream();
                    stream.CopyTo(memory);
                    byte[] data = memory.ToArray();
                    return data;
                }
            }

            return null;
        }

        private async void save(Object sender,EventArgs e) {
            var person = new Models.People {
                names=txt_names.Text,
                description=txt_description.Text,
                photo=image_to_array_byte()
            };

            if(await App.Instancia.add_person(person)>0) {
                await DisplayAlert("Aviso","Persona agregada","OK");
            } else {
                await DisplayAlert("Alerta","Ocurrio un error","OK");
            }
        }

        private async void btn_photo_Clicked(object sender,EventArgs e) {
            photo_camera=await CrossMedia.Current.TakePhotoAsync(new Plugin.Media.Abstractions.StoreCameraMediaOptions {
                Directory="MiAlbum",
                Name="Foto.jpg",
                SaveToAlbum=true
            });

            if(photo_camera!=null) {
                photo.Source=ImageSource.FromStream(() => {
                    return photo_camera.GetStream();
                });
            }
        }

        private async void view_list(object sender,EventArgs e) {
            await Navigation.PushAsync(new Page_list_people());
        }
    }
}