import * as React from 'react';
import { BottomNavigation, Provider as PaperProvider, Text, Card, Avatar, Button } from 'react-native-paper';
import { View, ScrollView, StyleSheet } from 'react-native';
import AsyncStorage from '@react-native-async-storage/async-storage';

const InicioRoute = () => (
  <View style={styles.content}>
    <Text>Inicio</Text>
  </View>
);

const LeftContent = props => <Avatar.Icon {...props} icon="scissors-cutting" />;

const ServicosRoute = () => (
  <ScrollView contentContainerStyle={styles.cardContainer}>
    {/* Card 1 */}
    <Card style={styles.card}>
      <Card.Title title="Corte Masculino" subtitle="R$ 30,00" left={LeftContent} />
      <Card.Content>
        <Text variant="bodyMedium">Corte moderno com finalização.</Text>
      </Card.Content>
      <Card.Cover source={{ uri: 'https://picsum.photos/300?1' }} />
      <Card.Actions>
        <Button>Agendar</Button>
        <Button>Detalhes</Button>
      </Card.Actions>
    </Card>

    {/* Card 2 */}
    <Card style={styles.card}>
      <Card.Title title="Barba Completa" subtitle="R$ 25,00" left={LeftContent} />
      <Card.Content>
        <Text variant="bodyMedium">Modelagem, hidratação e toalha quente.</Text>
      </Card.Content>
      <Card.Cover source={{ uri: 'https://picsum.photos/300?2' }} />
      <Card.Actions>
        <Button>Agendar</Button>
        <Button>Detalhes</Button>
      </Card.Actions>
    </Card>

    {/* Card 3 */}
    <Card style={styles.card}>
      <Card.Title title="Sobrancelha" subtitle="R$ 15,00" left={LeftContent} />
      <Card.Content>
        <Text variant="bodyMedium">Design com navalha para realce do olhar.</Text>
      </Card.Content>
      <Card.Cover source={{ uri: 'https://picsum.photos/300?3' }} />
      <Card.Actions>
        <Button>Agendar</Button>
        <Button>Detalhes</Button>
      </Card.Actions>
    </Card>

    {/* Card 4 */}
    <Card style={styles.card}>
      <Card.Title title="Corte Infantil" subtitle="R$ 20,00" left={LeftContent} />
      <Card.Content>
        <Text variant="bodyMedium">Corte estiloso para os pequenos.</Text>
      </Card.Content>
      <Card.Cover source={{ uri: 'https://picsum.photos/300?4' }} />
      <Card.Actions>
        <Button>Agendar</Button>
        <Button>Detalhes</Button>
      </Card.Actions>
    </Card>
  </ScrollView>
);

const NotificationsRoute = () => (
  <View style={styles.content}>
    <Text>Notificações</Text>
  </View>
);

const ContaRoute = () => {
  const [username, setUsername] = React.useState('');

  React.useEffect(() => {
    const fetchUsername = async () => {
      try {
        const storedUsername = await AsyncStorage.getItem('username');
        if (storedUsername) {
          setUsername(storedUsername);
        }
      } catch (error) {
        console.error('Erro ao buscar username:', error);
      }
    };
    fetchUsername();
  }, []);

  return (
    <View style={styles.content}>
      <Text>Olá, {username || 'usuário'}!</Text>
    </View>
  );
};

const BotaoNavegacao = () => {
  const [index, setIndex] = React.useState(0);
  const [routes] = React.useState([
    { key: 'inicio', title: 'Inicio', focusedIcon: 'warehouse' },
    { key: 'servicos', title: 'Serviços', focusedIcon: 'apps' },
    { key: 'conta', title: 'Conta', focusedIcon: 'account' },
    { key: 'notifications', title: 'Notificações', focusedIcon: 'bell' },
  ]);

  const renderScene = BottomNavigation.SceneMap({
    inicio: InicioRoute,
    servicos: ServicosRoute,
    conta: ContaRoute,
    notifications: NotificationsRoute,
  });

  return (
    <BottomNavigation
      navigationState={{ index, routes }}
      onIndexChange={setIndex}
      renderScene={renderScene}
    />
  );
};

export default function Index() {
  return (
    <PaperProvider>
      <BotaoNavegacao />
    </PaperProvider>
  );
}

const styles = StyleSheet.create({
  content: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
  },
  cardContainer: {
    padding: 16,
    alignItems: 'center',
  },
  card: {
    width: '100%',
    maxWidth: 400,
    marginBottom: 16,
  },
});
