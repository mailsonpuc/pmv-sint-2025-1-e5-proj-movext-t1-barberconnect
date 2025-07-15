import { Link } from 'expo-router';
import { StyleSheet, Text, View, TouchableOpacity } from 'react-native';
import { Button } from 'react-native-paper';

export default function HomeScreen() {
  return (
    <View style={styles.container}>
      <Text style={styles.title}>BarberConnect</Text>

      {/* Botão Cadastrar com Link e estilização */}
      <Link href="/Cadastrar" asChild>
        <TouchableOpacity style={styles.button}>
          <Text style={styles.buttonText}>Cadastrar</Text>
        </TouchableOpacity>
      </Link>

      {/* Botão Entrar com react-native-paper */}
      <Link href="/BotaoNavegacao" asChild>
        <Button icon="account-circle" mode="contained" style={styles.paperButton}>
          Entrar
        </Button>
      </Link>
    </View>
  );
}

const styles = StyleSheet.create({
  container: {
    flex: 1,
    justifyContent: 'center',
    alignItems: 'center',
    padding: 20,
    backgroundColor: '#fff',
  },
  title: {
    fontSize: 28,
    fontWeight: 'bold',
    marginBottom: 40,
  },
  button: {
    backgroundColor: '#4CAF50',
    paddingVertical: 12,
    paddingHorizontal: 30,
    borderRadius: 8,
    marginBottom: 20,
  },
  buttonText: {
    color: '#fff',
    fontSize: 16,
    fontWeight: '600',
  },
  paperButton: {
    width: 160,
    borderRadius: 8,
  },
});
