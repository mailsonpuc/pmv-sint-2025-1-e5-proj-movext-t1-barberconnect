import React, { useEffect, useState } from 'react';
import {
  View,
  Text,
  StyleSheet,
  ImageBackground,
  Image,
  TouchableOpacity,
  TextInput,
} from 'react-native';
import * as ImagePicker from 'expo-image-picker';
import PageContainer from '../components/PageContainer.js';

export default function MinhaConta() {
  const [modoEdicao, setModoEdicao] = useState(false);
  const [usuario, setUsuario] = useState({
    nome: 'Arthur Viotti',
    email: 'viottiarthur@email.com',
    telefone: '(32) 99999-9999',
    foto: null,
    ultimoAgendamento: {
      data: '22/05/2025',
      servico: 'Corte Degradê',
      barbeiro: 'Beatriz Ribeiro',
    },
  });

  const handleSair = () => {
    alert('Logout realizado com sucesso');
  };

  const handleSalvar = () => {
    setModoEdicao(false);
    alert('Dados atualizados com sucesso!');
  };

  const escolherFoto = async () => {
    const result = await ImagePicker.launchImageLibraryAsync({
      mediaTypes: ImagePicker.MediaTypeOptions.Images,
      allowsEditing: true,
      aspect: [1, 1],
      quality: 0.5,
    });

    if (!result.canceled) {
      setUsuario({ ...usuario, foto: result.assets[0].uri });
    }
  };

  return (
    <ImageBackground
      source={require('../assets/home-background.png')}
      style={styles.background}
    >
      <PageContainer>
        <Text style={styles.title}>Minha Conta</Text>

        <View style={styles.profileBox}>
          <TouchableOpacity onPress={modoEdicao ? escolherFoto : undefined}>
            {usuario.foto ? (
              <Image source={{ uri: usuario.foto }} style={styles.profileImage} />
            ) : (
              <View style={styles.avatarPlaceholder}>
                <Text style={styles.avatarText}>{usuario.nome[0]}</Text>
              </View>
            )}
          </TouchableOpacity>

          {modoEdicao ? (
            <TextInput
              style={styles.input}
              value={usuario.nome}
              onChangeText={(text) => setUsuario({ ...usuario, nome: text })}
              placeholder="Nome"
              placeholderTextColor="#aaa"
            />
          ) : (
            <Text style={styles.nome}>{usuario.nome}</Text>
          )}

          {modoEdicao ? (
            <TextInput
              style={styles.input}
              value={usuario.email}
              onChangeText={(text) => setUsuario({ ...usuario, email: text })}
              placeholder="Email"
              placeholderTextColor="#aaa"
            />
          ) : (
            <Text style={styles.email}>{usuario.email}</Text>
          )}

          {modoEdicao ? (
            <TextInput
              style={styles.input}
              value={usuario.telefone}
              onChangeText={(text) => setUsuario({ ...usuario, telefone: text })}
              placeholder="Telefone"
              placeholderTextColor="#aaa"
            />
          ) : (
            <Text style={styles.telefone}>{usuario.telefone}</Text>
          )}
        </View>

        <View style={styles.infoBox}>
          <Text style={styles.infoLabel}>Último agendamento:</Text>
          <Text style={styles.infoText}>{usuario.ultimoAgendamento.data} - {usuario.ultimoAgendamento.servico} ({usuario.ultimoAgendamento.barbeiro})</Text>
        </View>

        <View style={styles.buttonsBox}>
          {modoEdicao ? (
            <TouchableOpacity style={styles.button} onPress={handleSalvar}>
              <Text style={styles.buttonText}>Salvar</Text>
            </TouchableOpacity>
          ) : (
            <TouchableOpacity style={styles.button} onPress={() => setModoEdicao(true)}>
              <Text style={styles.buttonText}>Alterar Dados</Text>
            </TouchableOpacity>
          )}

          <TouchableOpacity style={styles.button} onPress={handleSair}>
            <Text style={styles.buttonText}>Sair</Text>
          </TouchableOpacity>
        </View>
      </PageContainer>
    </ImageBackground>
  );
}

const styles = StyleSheet.create({
  background: { flex: 1 },
  title: {
    color: '#fff',
    fontSize: 22,
    fontWeight: 'bold',
    textAlign: 'center',
    marginBottom: 30,
    marginTop: 200,
  },
  profileBox: {
    alignItems: 'center',
    marginBottom: 30,
  },
  profileImage: {
    width: 100,
    height: 100,
    borderRadius: 50,
    marginBottom: 15,
  },
  avatarPlaceholder: {
    width: 100,
    height: 100,
    borderRadius: 50,
    backgroundColor: '#555',
    justifyContent: 'center',
    alignItems: 'center',
    marginBottom: 15,
  },
  avatarText: {
    color: '#fff',
    fontSize: 36,
    fontWeight: 'bold',
  },
  nome: {
    color: '#fff',
    fontSize: 18,
    fontWeight: 'bold',
  },
  email: {
    color: '#ccc',
    fontSize: 14,
  },
  telefone: {
    color: '#ccc',
    fontSize: 14,
  },
  input: {
    backgroundColor: '#444',
    color: '#fff',
    fontSize: 14,
    padding: 8,
    borderRadius: 8,
    marginBottom: 10,
    width: '80%',
    textAlign: 'center',
  },
  infoBox: {
    marginBottom: 30,
    alignItems: 'center',
  },
  infoLabel: {
    color: '#fff',
    fontWeight: '600',
    marginBottom: 3,
  },
  infoText: {
    color: '#ccc',
    marginBottom: 10,
  },
  buttonsBox: {
    gap: 15,
  },
  button: {
    backgroundColor: '#555',
    borderRadius: 10,
    paddingVertical: 12,
    alignItems: 'center',
    marginBottom: 10,
  },
  buttonText: {
    color: '#fff',
    fontWeight: 'bold',
  },
});
